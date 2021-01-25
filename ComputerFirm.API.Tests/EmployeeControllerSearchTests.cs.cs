using System;
using Xunit;
using ComputerFirm.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ComputerFirm.API.Tests
{
    public class EmployeeControllerSearchTests
    {
        [Fact]
        public void ItExists()
        {
            var controller = new EmployeeController();
        }
	[Fact]
        public void ItHasSearch() //Проверяем наличие метода Поиск
        {
            var controller = new EmployeeController();
            controller.Search("Jos");
        }
	[Fact]
        public void ItReturnsOkObjectResult()
        { 
            var controller = new EmployeeController();
            var result = controller.Search("Jos");
            Assert.NotNull(result);                    //Поиск принес результат?
            Assert.IsType<OkObjectResult>(result);     //Результат ОК?
        }
        [Fact]
        public void ItReturnsCollectionOfEmployee()
        {
            var controller = new EmployeeController();
            var result = controller.Search("Jos") as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<List<Employee>>(result.Value);
        }
        [Fact]
        public void GivenExactMatchThenOneEmployeeInCollection()
        {
            var result = _controller.Search("Joshua") as OkObjectResult;
            var Employees = ((IEnumerable<Employee>)result.Value).ToList();
            Assert.Equal(1, Employees.Count);
        }
	    [Theory]
	    [InlineData("Joshua")]
	    [InlineData("joshua")]
	    [InlineData("JoShUa")]
	    public void GivenCaseInsensitveMatchThenEmployeeInCollection (string searchString)
	    {
		    var result = _controller.Search(searchString) as OkObjectResult;
		    var Employees = ((IEnumerable<Employee>)result.Value).ToList();
		    Assert.Equal(1, Employees.Count);
		    Assert.Equal("Joshua", Employees[0].Name);
        } 
        [Fact]
        public void GivenNoMatchThenEmptyCollection()
        {
            var result = _controller.Search("ZZZ") as OkObjectResult;
            var Employees = ((IEnumerable<Employee>)result.Value).ToList();
            Assert.Equal(0, Employees.Count);
        }
        [Fact]
        public void Given3MatchThenCollectionWith3Employees()
        {
            var result = _controller.Search("jos") as OkObjectResult;
            var Employees = ((IEnumerable<Employee>)result.Value).ToList();
            Assert.Equal(3, Employees.Count);
            Assert.True(Employees.Any(s => s.Name == "Josh"));
            Assert.True(Employees.Any(s => s.Name == "Joshua"));
            Assert.True(Employees.Any(s => s.Name == "Joseph"));
        }
        private readonly EmployeeController _controller;
        public EmployeeControllerSearchTests()
            {
            _controller = new EmployeeController();
            }
    }
}
