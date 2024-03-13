using DesktopMenu.QiNiu;
using Xunit;
using Xunit.Abstractions;

namespace DesktopMenuTests
{
    public class QiNiuTests
    {
        private readonly ITestOutputHelper _msg;

        public QiNiuTests(ITestOutputHelper msg)
        {
            _msg = msg;
        }

        [Fact]
        public void QiNiuUpLoading()
        {
            var ret = QiNiuHelper.QiNiuUpLoading("software/",@"C:\Users\ch190006\Desktop\test\123.exe");
            Assert.True(ret);
        }
        
        [Fact]
        public void DownloadFile()
        {
            var ret = QiNiuHelper.DownloadFile("http://kai.snblogs.cn/blog/article/1.jpg",@"C:\Users\ch190006\Desktop\test\下载\test.jpg");
            Assert.True(ret);
        } 
        
        [Fact]
        public void ListFiles()
        {
             QiNiuHelper.ListFiles("");
            // Assert.True();
        } 
       
    }
}