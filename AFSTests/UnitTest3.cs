using System;
using System.Collections.Generic;
using System.Text;
using AFS.APIConsumers;
using Moq;
using NUnit.Framework;

namespace AFSTests
{
    class UnitTest3
    {
       [Test]
       public void Test3()
        {
            var testString = "pierwszy test";
            var returnValue = "PYER\\/\\/ 5Zy 73St";
            var mock = new Mock<ITranslator>();
            mock.Setup(e => e.Translate(testString)).Returns(returnValue);
            var translator = new Translator(mock.Object);
            Assert.AreEqual(returnValue, translator.MakeTranslation(testString));
        }
        
    }
}
