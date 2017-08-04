using System;
using System.Collections;
using UnityEngine;

namespace GLTF
{
	public class GLTFByteArrayLoader : GLTFLoader
	{
		protected byte[] _gltfData;

		public GLTFByteArrayLoader(byte[] gltfData, Transform parent = null) : base(null, parent)
		{
			_gltfData = gltfData;
		}

		public override IEnumerator Load(int sceneIndex = -1)
		{
			if (Multithreaded)
			{
				yield return asyncAction.RunOnWorkerThread(() => ParseGLTF(_gltfData));
			}
			else
			{
				ParseGLTF(_gltfData);
			}

			Scene scene;
			if (sceneIndex >= 0 && sceneIndex < _root.Scenes.Count)
			{
				scene = _root.Scenes[sceneIndex];
			}
			else
			{
				scene = _root.GetDefaultScene();
			}

			if (scene == null)
			{
				throw new Exception("No default scene in gltf file.");
			}

			if (_lastLoadedScene == null)
			{
				if (_root.Buffers != null)
				{
					foreach (var buffer in _root.Buffers)
					{
						yield return LoadBuffer(buffer);
					}
				}

				if (_root.Images != null)
				{
					foreach (Image image in _root.Images)
					{
						yield return LoadImage(image);
					}
				}

				// generate these in advance instead of as-needed
				if (Multithreaded)
				{
					yield return asyncAction.RunOnWorkerThread(BuildMeshAttributes);
				}
			}

			GameObject sceneObj = CreateScene(scene);

			if (_sceneParent != null)
			{
				sceneObj.transform.SetParent(_sceneParent, false);
			}

			_lastLoadedScene = sceneObj;
		}
	}
}
