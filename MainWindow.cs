using LinuxPackageInstaller.Library;
using PackageFileReader.Library;

namespace LinuxPackageInstaller
{
    public partial class MainWindow : Form
    {
        private List<PackageFileReader.PackageModel> packages;
        private List<String> RepositoryList;
        public MainWindow()
        {
            InitializeComponent();
            RepositoryList = new List<String>();

            RepositoryList.Add("http://ftp.debian.org/debian/");

            DownloadFile.Download(RepositoryList[0] + "dists/Debian12.1/contrib/binary-all/Packages.gz", "Packages.gz");
            Unzip.UnzipFile("Packages.gz", "Packages");

            FileStream fileStream = new FileStream("Packages", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            PackageFileReader.Library.PackageFileReader fileReader = new PackageFileReader.Library.PackageFileReader(streamReader.ReadToEnd());
            List<PackageFileReader.PackageModel> packageModels = fileReader.ReadPackages();
            packageModels.ForEach(x => listView1.Items.Add(x.Name));
            packages = packageModels;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            packages.ForEach(x =>
            {
                if (x.Name == listView1.SelectedItems[0].Text.ToString())
                {
                    string url = "http://ftp.debian.org/debian/" + x.Url.Trim();
                    DownloadFile.Download(url, x.Name);
                }
            });
        }
    }
}