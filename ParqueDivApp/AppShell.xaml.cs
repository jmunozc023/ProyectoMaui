namespace ParqueDivApp
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Items.Add(new ShellContent
            {
                Content = new MainPage()
            });
        }

    }
}
