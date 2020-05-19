using Xunit;
using Controllers;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Test
{
    public class TestSettingsServices
    {
        private SettingsService _service; 
        private SettingsController _controller; 

        public TestSettingsServices()
        {
            _controller = new SettingsController();
            _service = new SettingsService();
        }

        [Fact]
        public void TestGetAllSettings()
        {
            var okResult = _controller.GetAllSettings();

            Assert.NotNull(_service.GetAllSettings());
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData("FullStackDeveloperSettings")]
        [InlineData("WebDeveloperSettings")]
        [InlineData("SharepointDeveloperSettings")]
        public void TestGetSettingsByConfigFile(string filename)
        {
            var okResult = _controller.GetSettingsByConfigFile(filename);
            
            Assert.NotNull(_service.GetSettingsByConfigFile(filename)); 
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData("F")]
        [InlineData("W")]
        public void TestErrorGetSettingsByConfigFile(string filename)
        {
            var notFoundResult = _controller.GetSettingsByConfigFile(filename);
            
            Assert.Null(_service.GetSettingsByConfigFile(filename)); 
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Theory]
        [InlineData("FullStackDeveloperSettings", "WebDeveloperSettings")]
        [InlineData("SharepointDeveloperSettings", "WebDeveloperSettings")]
        public void TestGetMergedConfigFile(string filename1, string filename2)
        {
            var okResult = _controller.GetMergedConfigFile(filename1, filename2);

            Assert.NotNull(_service.GetMergedConfigFile(filename1, filename2));
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData("F", "W")]
        [InlineData("S", "W")]
        public void TestErrorGetMergedConfigFile(string filename1, string filename2)
        {
            var notFoundResult = _controller.GetMergedConfigFile(filename1, filename2);

            Assert.Null(_service.GetMergedConfigFile(filename1, filename2));
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
         
    }
}
