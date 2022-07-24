namespace ProductVersion.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Start Versioning..");
            //var engine = new ReleaseEngine(String.Empty);
            var logger = new ConsoleLogger();// FileLogger();

            var engine = new ProductEngine(logger,
                new FileProductSource(),
                new JsonProductSerializer());

            engine.VersionDetails();

            if (String.IsNullOrEmpty(engine.VersionInfo))
            {
                Console.WriteLine("No version info produced.");
            }
            else
            {

                Console.WriteLine("Prodcut new verserion info: " + engine.VersionInfo);
            }
        }
    }
}