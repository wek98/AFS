using System;
using System.Collections.Generic;
using System.Text;
using AFS.Controllers;
using AFS.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;


namespace AFSTests
{
    class UnitTest2
    {

        [SetUp]
        public void Setup()
        {


        }
        [TestFixture]
        public class IndexPageRequest
        {
            private readonly RecordsContext _context;
            [Test]
            public void IndexPageReturn()
            {
                var controller = new HomeController(_context);
                var result = controller.Index() as ViewResult;
                var result2 = controller.Index2() as ViewResult;

                Assert.IsNotNull(result);
                Assert.IsNotNull(result2);

            }
        }
    }
}
