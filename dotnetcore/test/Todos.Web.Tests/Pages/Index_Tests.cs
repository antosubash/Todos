﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Todos.Pages
{
    public class Index_Tests : TodosWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
