using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace zoyobar.shared.panzer.test.ex
{

	public class EXTestHelper
	{

		public static bool InitDatabase(string name)
		{

			if(string.IsNullOrEmpty(name))
				return false;

			try
			{
				string folderPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\", string.Empty);
				string sourceDatabasePath = Path.Combine(folderPath, @"Test.mdf");
				string aimDatabasePath = Path.Combine(folderPath, name);

				if (File.Exists(aimDatabasePath))
					return true;

				if (!File.Exists(sourceDatabasePath))
					return false;

				File.Copy(sourceDatabasePath, aimDatabasePath, true);

				return true;
			}
			catch
			{ return false; }

		}

	}

}
