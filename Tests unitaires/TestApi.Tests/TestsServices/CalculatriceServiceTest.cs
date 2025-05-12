using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Tests.TestsServices
{
    public class CalculatriceServiceTest
    {
        [Fact]
        public void Addition_PrendDeuxEntiers_RetourneLaSomme()
        {
            //Arrange
            var service = new Calculatrice();

            //Act
            var result = service.addition(2, 5);

            //Assert
            Assert.Equal(7, result);
        }
    }
}
