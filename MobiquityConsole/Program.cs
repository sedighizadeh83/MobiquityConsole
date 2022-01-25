using MobiquityConsole.Exception;
using MobiquityConsole.Contollers;

namespace MobiquityConsole
{
    public class Program
    {
		public static void Main(String[] args)
		{
            if (args.Length > 0)
            {
                try
                {
                    var packer = new PackageController();
                    Console.WriteLine(packer.Pack(args[0]));
                }
                catch (System.Exception ex)
                {
                    throw new APIException(ex.ToString());
                }
            }
            else
            {
                throw new APIException("Please, enter a valid absolute filepath.");
            }
        }
	}
}