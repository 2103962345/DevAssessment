using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevAssessment.DependencyService
{
    public interface ITextToSpeechService
    {
        Task SpeakAsync(string text);
    }
}
