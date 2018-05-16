using System;
using System.Collections;
using System.IO;

namespace UnityGLTF.Loader
{
    public class StreamLoader : ILoader
    {
        public Stream LoadedStream { get; private set; }

        public StreamLoader(Stream loadedStream)
        {
            LoadedStream = loadedStream;
        }

        public IEnumerator LoadBaseStream()
        {
            if (LoadedStream == null)
            {
                throw new InvalidOperationException("LoadedStream is null.");
            }

            yield return null;
        }

        public IEnumerator LoadStream(string gltfFilePath)
        {
            throw new InvalidOperationException("StreamLoader does not load files.");
        }
    }
}
