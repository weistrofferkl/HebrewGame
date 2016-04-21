using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class PostBuildScript {
	public static string DATA_DIR = "DataFiles";
	
	// this attribute sets up the post process build call, the function name
	// doesn't matter, it's the attribute the flags it, but it does require those
	// two types of arguments and must be static
	[PostProcessBuild]
	public static void OnPostProcessBuild(BuildTarget target, string pathToBuildProject)
	{
		string appDataDir;

		// figure out where the data should be copied to, note I haven't really
		// tested with Windows, hahaha, but in theory that's where it goes
		switch (target)
		{
		case BuildTarget.iOS:
			appDataDir = "Data";
			break;
		case BuildTarget.StandaloneOSXIntel:
		case BuildTarget.StandaloneOSXIntel64:
		case BuildTarget.StandaloneOSXUniversal:
			appDataDir = "Contents";
			break;
		case BuildTarget.StandaloneWindows:
		case BuildTarget.StandaloneWindows64:
			appDataDir = Path.GetFileNameWithoutExtension(pathToBuildProject) + "_Data";
			break;
		default:
			Debug.Log ("Untested platform case, need to make sure the copy works!");
			throw new IOException ("Untested platform case for Post Build, need to make sure the copy works properly");
		}

		
		Debug.Log ("Building project at: " + pathToBuildProject);

		// just construct the two paths for the CopyAll
		string datadir = Application.dataPath
		                 + Path.DirectorySeparatorChar
		                 + PostBuildScript.DATA_DIR
		                 + Path.DirectorySeparatorChar;
			
		string copydir = pathToBuildProject
		                 + Path.DirectorySeparatorChar
		                 + appDataDir
		                 + Path.DirectorySeparatorChar
		                 + PostBuildScript.DATA_DIR
		                 + Path.DirectorySeparatorChar;
		
		Debug.Log ("Copying from: " + datadir + " to: " + copydir);

		// now do the copy all
		CopyAll (new DirectoryInfo (datadir), new DirectoryInfo(copydir));
	}


	public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
	{
		// init our recursive copyall
		CopyAllRec (source, target, 0, 0);
	}

	/// <summary>
	/// Recursive Copy Directory Method, modified from:
	///     http://www.ikriz.nl/2012/06/18/unity-post-process-mayhem/
	/// </summary>
	public static void CopyAllRec(DirectoryInfo source, DirectoryInfo target, int dircount, int filecount)
	{
		// Check if the target directory exists, if not, create it.
		if (Directory.Exists(target.FullName) == false)
		{
			dircount++;
			Directory.CreateDirectory(target.FullName);
		}

		// Copy each file into it’s new directory.
		foreach (FileInfo fi in source.GetFiles())
		{
			filecount++;
			fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
		}

		// Copy each subdirectory using recursion.
		foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		{
			dircount++;
			DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
			CopyAllRec(diSourceSubDir, nextTargetSubDir, dircount, filecount);
		}
	}
}
