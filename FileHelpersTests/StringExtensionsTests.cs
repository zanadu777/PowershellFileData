using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FileHelpers.Extensions;
using FluentAssertions;

namespace FileHelpersTests
{
    [TestClass]
    public class StringExtensionsTests

    {
        [TestMethod]
        public void PartTest()
        {
            var line =
                "step,type,amount,nameOrig,oldbalanceOrg,newbalanceOrig,nameDest,oldbalanceDest,newbalanceDest,isFraud,isFlaggedFraud";

            line.Part(',', 2).Should().Be("amount"); 
        }
    }
}
