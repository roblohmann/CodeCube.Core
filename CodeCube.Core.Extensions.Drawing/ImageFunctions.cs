using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace CodeCube.Core.Extensions.Drawing
{
    public class ImageFunctions
    {
        public Size GetImageDimensions(int currentWidth, int currentHeight, int destinationWidth, int destinationHeight)
        {
            // some sanity
            if (destinationWidth <= 0 || destinationHeight <= 0) return new Size(destinationWidth, destinationHeight);
            if (currentWidth <= 0 || currentHeight <= 0) return new Size(currentWidth, currentHeight);

            //double to hold the final multiplier to use when scaling the image
            double multiplier;
            double normalizedImageWidth = currentWidth;
            double normalizedImageHeight = currentHeight;

            // either current width or height are greater than destination
            if (currentWidth >= destinationWidth || currentHeight >= destinationHeight)
            {
                // current width dominates the scaling
                if (currentWidth > currentHeight)
                {
                    multiplier = (double)currentHeight / currentWidth;
                    normalizedImageWidth = destinationWidth;
                    normalizedImageHeight = Math.Min(destinationHeight, currentHeight) * multiplier;
                }
                else // current height dominates the scaling
                {
                    multiplier = (double)currentWidth / currentHeight;
                    normalizedImageWidth = Math.Min(destinationWidth, currentWidth) * multiplier;
                    normalizedImageHeight = destinationHeight;
                }
            }
            else
            {
                // both sides are less, scale out
                if (currentWidth > currentHeight)
                {
                    // destination width dominates the scaling
                    multiplier = (double)destinationWidth / currentWidth;
                }
                else
                {
                    // destination height dominates the scaling
                    multiplier = (double)destinationHeight / currentHeight;
                }
                normalizedImageWidth *= multiplier;
                normalizedImageHeight *= multiplier;
            }

            return new Size((int)normalizedImageWidth, (int)normalizedImageHeight);
        }

        /// <summary>
        /// Gets the image codec info for the provided mime type
        /// </summary>
        /// <param name="mimeType">The mimetype to get the codec info for. Eg. image/jpeg</param>
        /// <returns>An codecinco object.</returns>
        public ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            var codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            return codecs.FirstOrDefault(t => t.MimeType == mimeType);
        }

        /// <summary>
        /// Crops an image to the provided size.
        /// </summary>
        /// <param name="img">The image to crop</param>
        /// <param name="cropArea">The area of the image to crop</param>
        /// <returns>The croped image</returns>
        public Image CropImage(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            var bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);

            return bmpCrop;
        }
    }
}
