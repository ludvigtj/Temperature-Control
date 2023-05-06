using nanoFramework.TestFramework;
using System;
using System.Diagnostics;
using TemperatureControl.ViewModel.Shapes;

//FOR COPY PASTE PURPOSES - DO NOT EDIT
namespace TemperatureControl.Tests.Unit.GUIElementsTest
{
    [TestClass]
    public class ShapesTest
    {
        private static Shape _uut;
        [Setup]
        public void Setup()
        {

        }
        [TestMethod]
        public void Constructor_MiddlePoint_ReturnsCorrectRectangle()
        {
            //Arrange
            int lengthIn = 10;
            int heigthIn = 10;

            //Act
            Debug.WriteLine("Testing 10x10 rectangle centered on 10,10");
            _uut = new Rectangle(new Point(10, 10), lengthIn, heigthIn);

            //Assert
            var expTL = new Point(5, 15); 
            var expTR = new Point(15, 15); 
            var expBL = new Point(5,5); 
            var expBR = new Point(15, 5); 
            var points = _uut.Points;
            

            Assert.AreEqual(expTL.X, points[1].X);
            Assert.AreEqual(expTL.Y, points[1].Y);

            Assert.AreEqual(expTR.X, points[2].X);
            Assert.AreEqual(expTR.Y, points[2].Y);

            Assert.AreEqual(expBL.X, points[3].X);
            Assert.AreEqual(expBL.Y, points[3].Y);

            Assert.AreEqual(expBR.X, points[4].X);
            Assert.AreEqual(expBR.Y, points[4].Y);
        }


    }
}
