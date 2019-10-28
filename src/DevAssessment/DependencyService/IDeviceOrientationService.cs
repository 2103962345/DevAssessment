using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.DependencyService
{
    public interface IDeviceOrientationService
    {
        DeviceOrientation GetOrientation();
    }
}
