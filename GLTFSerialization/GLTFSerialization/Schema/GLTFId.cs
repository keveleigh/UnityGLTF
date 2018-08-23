using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GLTF.Schema
{
	/// <summary>
	/// Abstract class that stores a reference to the root GLTF object and an id
	/// of an object of type T inside it.
	/// </summary>
	/// <typeparam name="T">The value type returned by the GLTFId reference.</typeparam>
	[DataContract]
	public abstract class GLTFId<T>
	{
		[DataMember(Name = "id")]
		public int Id;
		public GLTFRoot Root;

		public abstract T Value { get; }

		protected GLTFId()
		{
		}

		public GLTFId(GLTFId<T> gltfId, GLTFRoot newRoot)
		{
			Id = gltfId.Id;
			Root = newRoot;
		}
	}

	public class AccessorId : GLTFId<Accessor>
	{
		public AccessorId()
		{
		}

		public AccessorId(AccessorId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Accessor Value
		{
			get { return Root.Accessors[Id]; }
		}
	}

	public class BufferId : GLTFId<Buffer>
	{
		public BufferId()
		{
		}

		public BufferId(BufferId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Buffer Value
		{
			get { return Root.Buffers[Id]; }
		}
	}

	public class BufferViewId : GLTFId<BufferView>
	{
		public BufferViewId()
		{
		}

		public BufferViewId(BufferViewId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override BufferView Value
		{
			get { return Root.BufferViews[Id]; }
		}
	}

	public class CameraId : GLTFId<Camera>
	{
		public CameraId()
		{
		}

		public CameraId(CameraId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Camera Value
		{
			get { return Root.Cameras[Id]; }
		}
	}

	public class ImageId : GLTFId<Image>
	{
		public ImageId()
		{
		}

		public ImageId(ImageId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}


		public override Image Value
		{
			get { return Root.Images[Id]; }
		}
	}

	public class MaterialId : GLTFId<Material>
	{
		public MaterialId()
		{
		}

		public MaterialId(MaterialId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Material Value
		{
			get { return Root.Materials[Id]; }
		}
	}

	public class MeshId : GLTFId<Mesh>
	{
		public MeshId()
		{
		}

		public MeshId(MeshId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Mesh Value
		{
			get { return Root.Meshes[Id]; }
		}
	}

	public class NodeId : GLTFId<Node>
	{
		public NodeId()
		{
		}

		public NodeId(NodeId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Node Value
		{
			get { return Root.Nodes[Id]; }
		}

		public static List<NodeId> ReadList(GLTFRoot root, JsonReader reader)
		{
			if (reader.Read() && reader.TokenType != JsonToken.StartArray)
			{
				throw new Exception("Invalid array.");
			}

			var list = new List<NodeId>();

			while (reader.Read() && reader.TokenType != JsonToken.EndArray)
			{
				var node = new NodeId
				{
					Id = int.Parse(reader.Value.ToString()),
					Root = root
				};

				list.Add(node);
			}

			return list;
		}
	}

	public class SamplerId : GLTFId<Sampler>
	{
		public SamplerId()
		{
		}

		public SamplerId(SamplerId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Sampler Value
		{
			get { return Root.Samplers[Id]; }
		}
	}

	public class SceneId : GLTFId<Scene>
	{
		public SceneId()
		{
		}

		public SceneId(SceneId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}


		public override Scene Value
		{
			get { return Root.Scenes[Id]; }
		}
	}

	public class SkinId : GLTFId<Skin>
	{
		public SkinId()
		{
		}

		public SkinId(SkinId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Skin Value
		{
			get { return Root.Skins[Id]; }
		}
	}

	public class TextureId : GLTFId<Texture>
	{
		public TextureId()
		{
		}

		public TextureId(TextureId id, GLTFRoot newRoot) : base(id, newRoot)
		{
		}

		public override Texture Value
		{
			get { return Root.Textures[Id]; }
		}
	}
}
