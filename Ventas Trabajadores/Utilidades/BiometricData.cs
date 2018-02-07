using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrFingerXLib;  

namespace Griaule.BiometricData
{
    
        // Raw image data type.
        public struct TRawImage
        {
            //Image data.
            public object img;
            // Image width.
            public int width;
            // Image height.
            public int height;
            // Image resolution.
            public int Res;
        }

        // the template class
        public class TTemplate
        {
            // Template data.
            public System.Array _tpt;
            // Template size
            public int _size;
            //Template quality
            public int _quality;

            public TTemplate()
            {
                // Create a byte buffer for the template
                _tpt = new byte[(int)GRConstants.GR_MAX_SIZE_TEMPLATE];
                _size = 0;
            }
        }
}
