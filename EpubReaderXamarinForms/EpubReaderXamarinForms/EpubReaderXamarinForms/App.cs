using Xamarin.Forms;

namespace EpubReaderXamarinForms
{
    public class App : Application
    {
        public App()
        {
            //string bookPath = "obitaemij-ostrov.epub";
            //string bookPath = "alice-in-wonderland.epub";
            //string archivePath = "doc.zip";

            IEpubReader epubReader = DependencyService.Get<IEpubReader>();
            Book book = epubReader.ReadEpub(/*bookPath*/);

            MainPage = new MainPage(book);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
