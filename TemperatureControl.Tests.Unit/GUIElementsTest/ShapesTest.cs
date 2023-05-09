//using nanoFramework.TestFramework;
//using System.Drawing;
//using System;
//using System.Diagnostics;
//using TemperatureControl.ViewModel.Shapes;

////FOR COPY PASTE PURPOSES - DO NOT EDIT
//namespace TemperatureControl.Tests.Unit.GUIElementsTest
//{
//    [TestClass]
//    public class ShapesTest
//    {
//        private static Shape _uut;
//        [Setup]
//        public void Setup()
//        {

//        }
//        [TestMethod]
//        public void Constructor_CasesOfRadii_ReturnsCorrectRectangle()
//        {
//            //Arrange
//            int xRadius = 5;
//            int yRadius = 5;

//            int xRadiusNegative = -1;
//            int yRadiusNegative = -1;

//            int xRadiusLarge = 100;
//            int yRadiusLarge = 100;


//            //Act
//            Debug.WriteLine("Testing 10x10 rectangle");
//            Point center = new Point(10,10);
//            _uut = new Rectangle(center, xRadius, yRadius);
//            Shape Negative = new Rectangle(center, xRadiusNegative, yRadiusNegative);
//            Shape Large = new Rectangle(center, xRadiusLarge, yRadiusLarge);
//            Shape[] units = { _uut, Negative, Large };

//            //Assert
//            var expTL = new Point(5, 15); 
//            var expTR = new Point(15, 15); 
//            var expBL = new Point(5,5); 
//            var expBR = new Point(15, 5);

//            var expTLNegative = center;
//            var expTRNegative = center;
//            var expBLNegative = center;
//            var expBRNegative = center;

//            var expTLLarge = new Point(0, 20);
//            var expTRLarge = new Point(20, 20);
//            var expBLLarge = new Point(0, 0);
//            var expBRLarge = new Point(20, 0);


//            Point[] tlPoints = new Point[] { expTL, expTLNegative, expTLLarge };
//            Point[] trPoints = new Point[] { expTR, expTRNegative, expTRLarge };
//            Point[] blPoints = new Point[] { expBL, expBLNegative, expBLLarge };
//            Point[] brPoints = new Point[] { expBR, expBRNegative, expBRLarge };

//            for (int i = 0; i < units.Length; i++)
//            {
//                var points = units[i].Points;
//                Debug.WriteLine($"{points[1].GetCoords()}/{points[2].GetCoords()}/{points[3].GetCoords()}/{points[4].GetCoords()}/");

//                Assert.AreEqual(tlPoints[i].X, points[1].X);
//                Assert.AreEqual(tlPoints[i].Y, points[1].Y);

//                Assert.AreEqual(trPoints[i].X, points[2].X);
//                Assert.AreEqual(trPoints[i].Y, points[2].Y);

//                Assert.AreEqual(blPoints[i].X, points[3].X);
//                Assert.AreEqual(blPoints[i].Y, points[3].Y);

//                Assert.AreEqual(brPoints[i].X, points[4].X);
//                Assert.AreEqual(brPoints[i].Y, points[4].Y);
//                Debug.WriteLine("Unit passed: " + i);
//            }

            
//        }

//        [TestMethod]
//        public void RectangleGetFill_IncreasingOutlineGreenColor_ReturnsCorrect()
//        {
//            ushort colorGreen = Color.MediumSeaGreen.To12bppRgb444();
//            Debug.WriteLine($"Testing for color: {colorGreen}");
//            Point center = new Point(10, 10);
//            int fullLength = 10;
//            int fullHeigth = 10;
//            _uut = new Rectangle(center, fullLength, fullHeigth);

//            for (ushort outlineThickness = 0; outlineThickness < 5; outlineThickness++)
//            {
//                Pixel[] fillPixels = _uut.GetFill(outlineThickness, colorGreen);
//                int n = -1;
//                Rectangle uutMinusOutline = new Rectangle(center,
//                    10 - outlineThickness,
//                    10 - outlineThickness);

//                Debug.WriteLine("Testing:" + outlineThickness);
//                Debug.WriteLine($"Y range: {uutMinusOutline.BottomLeft.Y}/{uutMinusOutline.TopLeft.Y}\n" +
//                                $"X range: {uutMinusOutline.BottomLeft.X}/{uutMinusOutline.BottomRight.X}");
//                for (int i = 0; i < fillPixels.Length; i++)
//                {
//                    n = i;
//                    Debug.WriteLine($"P:{fillPixels[i].X},{fillPixels[i].Y}");
//                    Assert.IsTrue(uutMinusOutline.IsPointWithinArea(fillPixels[i]));
//                    Assert.AreEqual(fillPixels[i].Color, colorGreen);
//                }
//            }
            
//        }


//    }
//}
