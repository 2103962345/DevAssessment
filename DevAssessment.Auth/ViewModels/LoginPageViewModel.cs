using DevAssessment.Auth.MockServices;
using DevAssessment.Auth.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAssessment.Auth.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ILoginManager _loginManager;
        private readonly IJwtAuthService _jwtAuthService;

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                  IEventAggregator eventAggregator, ILoginManager loginManager, IJwtAuthService jwtAuthService)
                                    
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _eventAggregator = eventAggregator;
            _loginManager = loginManager;
            _jwtAuthService = jwtAuthService;
           
            OnLoginCommand = new DelegateCommand(async () => await GoToWelcomePage());

        }

        private string _userName;

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);

                if (!string.IsNullOrEmpty(_email))
                {
                    var Name = _email.Split('@')[0];
                    if (!string.IsNullOrEmpty(Name))
                        _userName = Name;
                }

            }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }



        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set { SetProperty(ref _isValid, value); }
        }


        public DelegateCommand OnLoginCommand { get; set; }


        async Task GoToWelcomePage()
        {
            try
            {
                if (string.IsNullOrEmpty(Email))
                {
                    await _pageDialogService.DisplayAlertAsync("Alert", "UserName is required", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    await _pageDialogService.DisplayAlertAsync("Alert", "Password is required", "Ok");
                    return;
                }

                var isUserNameValid = (Regex.IsMatch(Email, Constants.EmailRegex));

                if (!isUserNameValid)
                {
                    await _pageDialogService.DisplayAlertAsync("Alert", "Email is not Valid", "Ok");
                    return;
                }

                var isValidUser = await _loginManager.LoginUser(new User { UserName = Email, Password = Password});

                if (!isValidUser)
                {
                    await _pageDialogService.DisplayAlertAsync("Error!", "Email or Password is wrong", "Ok");
                    return;
                }

                var isTokenGenerated = await IsJwtTokenGenerated();

                if (!isTokenGenerated)
                {
                    await _pageDialogService.DisplayAlertAsync("Bad Request", "Can't Login", "Ok");
                    return;
                }

                _eventAggregator.GetEvent<UserTypeEvent>().Publish(_userName);

                var isAdmin = await _loginManager.IsAdmin(Email);

                Application.Current.Properties[Constants.IsAdmin] = isAdmin;
                await Application.Current.SavePropertiesAsync();

                //reseting MainPage after Login Page,

                await _navigationService.NavigateAsync(new Uri("app:///MainPage/NavigationPage/HomePage", UriKind.Absolute));

               

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

            
            //await _navigationService.NavigateAsync("MainPage");

        }


        async Task<bool> IsJwtTokenGenerated()
        {

            JWTContainer container = GetJwtContainer(_userName, Email);
            var token = _jwtAuthService.GenerateToken(container);

            if (!_jwtAuthService.IsTokenValid(token))
                return false;
            else
            {
                
                var handler = new JwtSecurityTokenHandler();
                var readToken = handler.ReadToken(token);
                var tokenValidationTime = readToken.ValidTo;

                // for presisting the jwt token and its valid datetime.
                Application.Current.Properties[Constants.JwtToken] = token;
                Application.Current.Properties[Constants.JwtTokenValidTime] = tokenValidationTime;
                await Application.Current.SavePropertiesAsync();
                return true;
            }

        }

        private JWTContainer GetJwtContainer(string name, string email)
        {
            return new JWTContainer()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }


    }


}

