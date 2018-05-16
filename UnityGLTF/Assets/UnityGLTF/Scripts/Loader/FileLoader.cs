using System;
using System.Collections;
using System.IO;

namespace UnityGLTF.Loader
{
	public class FileLoader : ILoader
	{
		public Stream LoadedStream { get; private set; }

		private string _rootFilePath;
		private string _rootDirectoryPath;

		public FileLoader(string fullFilePath)
		{
			_rootFilePath = Path.GetFileName(fullFilePath);
			_rootDirectoryPath = URIHelper.GetDirectoryName(fullFilePath);
		}

		public IEnumerator LoadBaseStream()
		{
			if (_rootFilePath == null)
			{
				throw new InvalidOperationException("_rootFilePath is null.");
			}

			yield return LoadFileStream(_rootDirectoryPath, _rootFilePath);
		}

		public IEnumerator LoadStream(string gltfFilePath)
		{
			if (gltfFilePath == null)
			{
				throw new ArgumentNullException("gltfFilePath");
			}

			yield return LoadFileStream(_rootDirectoryPath, gltfFilePath);
		}

		private IEnumerator LoadFileStream(string rootPath, string fileToLoad)
		{
			string pathToLoad = Path.Combine(rootPath, fileToLoad);
			if (!File.Exists(pathToLoad))
			{
				throw new FileNotFoundException("Buffer file not found", fileToLoad);
			}

			yield return null;
			LoadedStream = File.OpenRead(pathToLoad);
		}
	}
}
