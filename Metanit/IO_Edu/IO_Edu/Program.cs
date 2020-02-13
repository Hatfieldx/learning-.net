using System;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Text.Json;

namespace IO_Edu
{
    [Serializable]
    class Car
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string Factory { get; set; }

        public int MaxSpeed { get; set; }

        public Car()
        {

        }

        public Car(string name, string model, string factory, int maxSpeed)
        {
            Name = name;
            Model = Model;
            Factory = factory;
            MaxSpeed = maxSpeed;
        }

        public void Info() => Console.WriteLine($"{Name}=>{Model}=>{Factory}=>{MaxSpeed}");

    }

    class Program
    {
        static void Main(string[] args)
        {
            // DriveInfoMethod();

            //DirectoryMethod();

            //Streams();            

            //Serializations();

            // DeSerializations();

            //Archive();

            //FanWithJson();

            //NotifiTest();

            Console.WriteLine("Main thred is finished");

            Console.ReadKey();
        }

        private static void NotifiTest()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher(@"d:\test dir"))
            {
                watcher.Created += (sender, args) => { Console.WriteLine($"Smth created {args.Name} - {args.ChangeType}"); };

                watcher.Deleted += (sender, args) => { Console.WriteLine($"Smth Deleted {args.Name} - {args.ChangeType}"); };

                watcher.Renamed += (sender, args) => { Console.WriteLine($"Smth Renamed {args.Name} - {args.ChangeType}"); };

                while(true)
                watcher.WaitForChanged(WatcherChangeTypes.All);
            }           
            
        }



        private static void FanWithJson()
        {
            string path = @"D:\test dir\program\car.json";

            Car car = new Car()
            {
                Name = "LadaCrava",
                Model = "Shaha",
                MaxSpeed = 50,
                Factory = "Garage"
            };

            var jsonOptions = new JsonSerializerOptions()
            {
               WriteIndented = true
            };

            if (File.Exists(path))
                File.Delete(path);

            string serializedCar = JsonSerializer.Serialize(car, jsonOptions);

            File.WriteAllText(path, serializedCar);

            Car res = JsonSerializer.Deserialize<Car>(File.ReadAllText(path), jsonOptions);

            int st = 0;
        }

        private static void Archive()
        {
            string path = @"D:\test dir\program";

            string[] pathFiles = SearchFile(path, @"*.pdf");

            if (pathFiles.Length == 0)
                throw new Exception($"no any files in path {path}");

            ZipFile.CreateFromDirectory(path, path + ".zip");

            ZipFile.ExtractToDirectory(path + ".zip", path + "decompressed");
            
            //(from pathfile in pathFiles select pathfile).AsParallel().ForAll(x=> DoArchiveFiles(x));

            //var t = Parallel.ForEach(pathFiles, x => DoArchiveFiles(x));

            //while (!t.IsCompleted) ;

            //pathFiles = SearchFile(path, @"*.gz");

            //DoDecompress(pathFiles[0]);




        }

        private static void DoDecompress(string pathFile)
        {
            using (FileStream src = new FileStream(pathFile, FileMode.Open))
            {
                using (FileStream target = File.Create(pathFile + "DECOMPRESS.pdf"))
                {
                    string destPth = target.Name;

                    using (GZipStream decompress = new GZipStream(src, CompressionMode.Decompress))
                    {
                        decompress.CopyTo(target);
                    }

                    FileInfo srcPath = new FileInfo(pathFile);

                    FileInfo dst = new FileInfo(destPth);

                    Console.WriteLine($"DECompressed { srcPath.Name} from { srcPath.Length.ToString()} to { dst.Length.ToString()} bytes.");
                }
            } 
        }

        private static void DoArchiveFiles(string pathFile)
        {
            using (FileStream source = new FileStream(pathFile, FileMode.Open))
            {
                using (FileStream target = File.Create(pathFile + ".gz")) //new FileStream(Path.GetPathRoot(firstfile) + "1.gz", FileMode.OpenOrCreate))
                {
                    string destPth = target.Name;

                    using (GZipStream compression = new GZipStream(target, CompressionMode.Compress))
                    {
                        source.CopyTo(compression);
                    }

                    FileInfo src = new FileInfo(pathFile);

                    FileInfo dst = new FileInfo(destPth);

                    Console.WriteLine($"Compressed { src.Name} from { src.Length.ToString()} to { dst.Length.ToString()} bytes.");
                }
            }
        }

        private static string[] SearchFile(string path, string pattern)
        {
            if (!Directory.Exists(path))
                throw new Exception("path isnt exist");

            return Directory.GetFiles(path, pattern);
        }

        private static void Serializations()
        {
            Car car = new Car()
            {
                Name = "LadaCrava",
                Model = "Shaha",
                MaxSpeed = 50,
                Factory = "Garage"
            };

            car.Info();
            string path = @"d:\test dir\serias.dat";

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, car);
            }

        }

        private static void DeSerializations()
        {
            string path = @"d:\test dir\serias.dat";

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Car car = (Car)bf.Deserialize(fs);
                car.Info();
            }

        }

        private static void Streams()
        {
            string str = "";

            for (int i = 0; i < 50000; i++)
            {
                str += i.ToString() + "\n";
            }

            string path = @"d:\test dir\swr.txt";

            Task writter = WriteWithWriterAsync(str, path);

            writter.Wait();

            Task<string> reader = ReadWithReaderAsync(path);

            string s = reader.Result;

            Console.WriteLine(s);
        }

        private static async Task<string> ReadWithReaderAsync(string path)
        {
            Console.WriteLine("Start READER");

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                return await sr.ReadToEndAsync();
            }
        }

        static async Task WriteWithWriterAsync(string s, string path)
        {
            Console.WriteLine("Start Writter");

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                await sw.WriteAsync(s);
            }

            Console.WriteLine("Stop Writter");
        }

        private static void DirectoryMethod()
        {
            Console.WriteLine(new string('=', 10) + "Directory info");

            string path = @"d:\";

            if (Directory.Exists(path))
            {
                Console.WriteLine("Sub dir d:\\ :");

                string[] subDirs = Directory.GetDirectories(path);

                foreach (var item in subDirs)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                Console.WriteLine("Files: ");

                (from filesLinq in Directory.GetFiles(path) select filesLinq).AsParallel().ForAll((x) => Console.WriteLine($"LINQ files is {x}"));

                string path1 = @"d:\test dir";

                string subDir = @"program\test sub dir";

                DirectoryInfo dif = new DirectoryInfo(path1);

                if (!dif.Exists)
                {
                    dif.Create();

                    dif.CreateSubdirectory(subDir);
                }

                string topPath = Directory.GetDirectories(@"d:\")[0];

                DirectoryInfo dirInfo = new DirectoryInfo(topPath);

                Console.WriteLine($"FullName {dirInfo.FullName}");
                Console.WriteLine($"Root {dirInfo.Root}");
                Console.WriteLine($"Parent {dirInfo.Parent}");
                Console.WriteLine($"CreationTime {dirInfo.CreationTime}");

                // dif.Delete(true);

                string str = "";

                for (int i = 0; i < 50000; i++)
                {
                    str += i.ToString() + "\n";
                }

                WriteFile(str, dif.FullName);

                Task<string> t = ReadFile(dif.FullName);

                string g = t.Result;
            }
        }

        private static void DriveInfoMethod()
        {
            Console.WriteLine(new string('=', 10) + "Drive info");

            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach (var item in drivesInfo)
            {
                Console.WriteLine(item.Name);
            }

            (from drInf in drivesInfo.AsParallel() where drInf.IsReady select drInf).ForAll((x) => Console.WriteLine($"{x.Name} => {x.IsReady} => {x.TotalSize / 1000000} => {x.AvailableFreeSpace / 1000000}"));
        }

        static async void WriteFile(string s, string path)
        {
            using (FileStream fs = new FileStream(path + "\\test.txt", FileMode.Create))
            {
                if (fs.CanWrite)
                {
                    await fs.WriteAsync(Encoding.Default.GetBytes(s));
                }
            }

            Console.WriteLine("Writting is finished");
        }

        static async Task<string> ReadFile(string path)
        {

            string s = "";

            using (FileStream fs = new FileStream(path + "\\test.txt", FileMode.Open))
            {
                if (fs.CanRead)
                {
                    byte[] res = new byte[fs.Length];

                    await fs.ReadAsync(res);

                    s = Encoding.Default.GetString(res);
                }
            }

            Console.WriteLine("Reading is finished");

            return s;
        }
    }
}
