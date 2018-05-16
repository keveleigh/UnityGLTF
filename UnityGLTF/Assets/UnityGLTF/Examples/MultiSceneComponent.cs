using System.Collections;
using UnityEngine;
using UnityGLTF.Loader;

namespace UnityGLTF.Examples
{
	public class MultiSceneComponent : MonoBehaviour
	{
		public int SceneIndex = 0;
		public string Url;

		private GLTFSceneImporter _importer;
		private ILoader _loader;

		void Start()
		{
			Debug.Log("Hit spacebar to change the scene.");

			_loader = new WebRequestLoader(Url);

			StartCoroutine(LoadScene(SceneIndex));
		}

		void Update()
		{
			if (Input.GetKeyDown("space"))
			{
				SceneIndex = SceneIndex == 0 ? 1 : 0;
				Debug.LogFormat("Loading scene {0}", SceneIndex);
				StartCoroutine(LoadScene(SceneIndex));
			}
		}

		IEnumerator LoadScene(int SceneIndex)
		{
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}

			_importer = new GLTFSceneImporter(_loader)
			{
				SceneParent = gameObject.transform
			};

			yield return _importer.LoadScene(SceneIndex);
		}
	}
}
