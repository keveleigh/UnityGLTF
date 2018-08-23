using GLTF.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GLTF.Schema
{
	/// <summary>
	/// The root object for a glTF asset.
	/// </summary>
	[DataContract]
	public class GLTFRoot : GLTFProperty
	{
		/// <summary>
		/// Names of glTF extensions used somewhere in this asset.
		/// </summary>
		[DataMember(Name = "extensionsUsed")]
		public List<string> ExtensionsUsed;

		/// <summary>
		/// Names of glTF extensions required to properly load this asset.
		/// </summary>
		[DataMember(Name = "extensionsRequired")]
		public List<string> ExtensionsRequired;

		/// <summary>
		/// An array of accessors. An accessor is a typed view into a bufferView.
		/// </summary>
		[DataMember(Name = "accessors")]
		public List<Accessor> Accessors;

		/// <summary>
		/// An array of keyframe animations.
		/// </summary>
		[DataMember(Name = "animations")]
		public List<Animation> Animations;

		/// <summary>
		/// Metadata about the glTF asset.
		/// </summary>
		[DataMember(Name = "asset")]
		public Asset Asset;

		/// <summary>
		/// An array of buffers. A buffer points to binary geometry, animation, or skins.
		/// </summary>
		[DataMember(Name = "buffers")]
		public List<Buffer> Buffers;

		/// <summary>
		/// An array of bufferViews.
		/// A bufferView is a view into a buffer generally representing a subset of the buffer.
		/// </summary>
		[DataMember(Name = "bufferViews")]
		public List<BufferView> BufferViews;

		/// <summary>
		/// An array of cameras. A camera defines a projection matrix.
		/// </summary>
		[DataMember(Name = "cameras")]
		public List<Camera> Cameras;

		/// <summary>
		/// An array of images. An image defines data used to create a texture.
		/// </summary>
		[DataMember(Name = "images")]
		public List<Image> Images;

		/// <summary>
		/// An array of materials. A material defines the appearance of a primitive.
		/// </summary>
		[DataMember(Name = "materials")]
		public List<Material> Materials;

		/// <summary>
		/// An array of meshes. A mesh is a set of primitives to be rendered.
		/// </summary>
		[DataMember(Name = "meshes")]
		public List<Mesh> Meshes;

		/// <summary>
		/// An array of nodes.
		/// </summary>
		[DataMember(Name = "nodes")]
		public List<Node> Nodes;

		/// <summary>
		/// An array of samplers. A sampler contains properties for texture filtering and wrapping modes.
		/// </summary>
		[DataMember(Name = "samplers")]
		public List<Sampler> Samplers;

		/// <summary>
		/// The index of the default scene.
		/// </summary>
		[DataMember(Name = "scene")]
		public SceneId Scene;

		/// <summary>
		/// An array of scenes.
		/// </summary>
		[DataMember(Name = "scenes")]
		public List<Scene> Scenes;

		/// <summary>
		/// An array of skins. A skin is defined by joints and matrices.
		/// </summary>
		[DataMember(Name = "skins")]
		public List<Skin> Skins;

		/// <summary>
		/// An array of textures.
		/// </summary>
		[DataMember(Name = "textures")]
		public List<Texture> Textures;

		public GLTFRoot()
		{
		}

		public GLTFRoot(GLTFRoot gltfRoot) : base(gltfRoot)
		{
			if (gltfRoot.ExtensionsUsed != null)
			{
				ExtensionsUsed = gltfRoot.ExtensionsUsed.ToList();
			}

			if (gltfRoot.ExtensionsRequired != null)
			{
				ExtensionsRequired = gltfRoot.ExtensionsRequired.ToList();
			}

			if (gltfRoot.Accessors != null)
			{
				Accessors = new List<Accessor>(gltfRoot.Accessors.Count);
				foreach (Accessor accessor in gltfRoot.Accessors)
				{
					Accessors.Add(new Accessor(accessor, this));
				}
			}

			if (gltfRoot.Animations != null)
			{
				Animations = new List<Animation>(gltfRoot.Animations.Count);
				foreach (Animation animation in gltfRoot.Animations)
				{
					Animations.Add(new Animation(animation, this));
				}
			}

			if (gltfRoot.Asset != null)
			{
				Asset = new Asset(gltfRoot.Asset);
			}

			if (gltfRoot.Buffers != null)
			{
				Buffers = new List<Buffer>(gltfRoot.Buffers.Count);
				foreach (Buffer buffer in gltfRoot.Buffers)
				{
					Buffers.Add(new Buffer(buffer, this));
				}
			}

			if (gltfRoot.BufferViews != null)
			{
				BufferViews = new List<BufferView>(gltfRoot.BufferViews.Count);
				foreach (BufferView bufferView in gltfRoot.BufferViews)
				{
					BufferViews.Add(new BufferView(bufferView, this));
				}
			}
			
			if (gltfRoot.Cameras != null)
			{
				Cameras = new List<Camera>(gltfRoot.Cameras.Count);
				foreach (Camera camera in gltfRoot.Cameras)
				{
					Cameras.Add(new Camera(camera, this));
				}
			}

			if (gltfRoot.Images != null)
			{
				Images = new List<Image>(gltfRoot.Images.Count);
				foreach (Image image in gltfRoot.Images)
				{
					Images.Add(new Image(image, this));
				}
			}

			if (gltfRoot.Materials != null)
			{
				Materials = new List<Material>(gltfRoot.Materials.Count);
				foreach (Material material in gltfRoot.Materials)
				{
					Materials.Add(new Material(material, this));
				}
			}

			if (gltfRoot.Meshes != null)
			{
				Meshes = new List<Mesh>(gltfRoot.Meshes.Count);
				foreach (Mesh mesh in gltfRoot.Meshes)
				{
					Meshes.Add(new Mesh(mesh, this));
				}
			}

			if (gltfRoot.Nodes != null)
			{
				Nodes = new List<Node>(gltfRoot.Nodes.Count);
				foreach (Node node in gltfRoot.Nodes)
				{
					Nodes.Add(new Node(node, this));
				}
			}

			if (gltfRoot.Samplers != null)
			{
				Samplers = new List<Sampler>(gltfRoot.Samplers.Count);
				foreach (Sampler sampler in gltfRoot.Samplers)
				{
					Samplers.Add(new Sampler(sampler, this));
				}
			}

			if (gltfRoot.Scene != null)
			{
				Scene = new SceneId(gltfRoot.Scene, this);
			}
			
			if (gltfRoot.Scenes != null)
			{
				Scenes = new List<Scene>(gltfRoot.Scenes.Count);
				foreach (Scene scene in gltfRoot.Scenes)
				{
					Scenes.Add(new Scene(scene, this));
				}
			}
			
			if (gltfRoot.Skins != null)
			{
				Skins = new List<Skin>(gltfRoot.Skins.Count);
				foreach (Skin skin in gltfRoot.Skins)
				{
					Skins.Add(new Skin(skin, this));
				}
			}
			
			if (gltfRoot.Textures != null)
			{
				Textures = new List<Texture>(gltfRoot.Textures.Count);
				foreach (Texture texture in gltfRoot.Textures)
				{
					Textures.Add(new Texture(texture, this));
				}
			}
		}

		/// <summary>
		/// Return the default scene. When scene is null, scene of index 0 will be returned.
		/// When scenes list is null or empty, returns null.
		/// </summary>
		public Scene GetDefaultScene()
		{
			if (Scene != null)
			{
				return Scene.Value;
			}

			if (Scenes.Count > 0)
			{
				return Scenes[0];
			}

			return null;
		}

		public static GLTFRoot Deserialize(Stream dataStream, DataContractJsonSerializerSettings settings = null)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GLTFRoot));

			return serializer.ReadObject(dataStream) as GLTFRoot;

			if (jsonReader.Read() && jsonReader.TokenType != JsonToken.StartObject)
			{
				throw new Exception("gltf json must be an object");
			}

			while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
			{
				var curProp = jsonReader.Value.ToString();

				switch (curProp)
				{
					case "accessors":
						root.Accessors = jsonReader.ReadList(() => Accessor.Deserialize(root, jsonReader));
						break;
					case "animations":
						root.Animations = jsonReader.ReadList(() => Animation.Deserialize(root, jsonReader));
						break;
					case "asset":
						root.Asset = Asset.Deserialize(root, jsonReader);
						break;
					case "buffers":
						root.Buffers = jsonReader.ReadList(() => Buffer.Deserialize(root, jsonReader));
						break;
					case "bufferViews":
						root.BufferViews = jsonReader.ReadList(() => BufferView.Deserialize(root, jsonReader));
						break;
					case "cameras":
						root.Cameras = jsonReader.ReadList(() => Camera.Deserialize(root, jsonReader));
						break;
					case "images":
						root.Images = jsonReader.ReadList(() => Image.Deserialize(root, jsonReader));
						break;
					case "materials":
						root.Materials = jsonReader.ReadList(() => Material.Deserialize(root, jsonReader));
						break;
					case "meshes":
						root.Meshes = jsonReader.ReadList(() => Mesh.Deserialize(root, jsonReader));
						break;
					case "nodes":
						root.Nodes = jsonReader.ReadList(() => Node.Deserialize(root, jsonReader));
						break;
					case "samplers":
						root.Samplers = jsonReader.ReadList(() => Sampler.Deserialize(root, jsonReader));
						break;
					case "scene":
						root.Scene = SceneId.Deserialize(root, jsonReader);
						break;
					case "scenes":
						root.Scenes = jsonReader.ReadList(() => GLTF.Schema.Scene.Deserialize(root, jsonReader));
						break;
					case "skins":
						root.Skins = jsonReader.ReadList(() => Skin.Deserialize(root, jsonReader));
						break;
					case "textures":
						root.Textures = jsonReader.ReadList(() => Texture.Deserialize(root, jsonReader));
						break;
					default:
						root.DefaultPropertyDeserializer(root, jsonReader);
						break;
				}
			}

			return root;
		}

		public void Serialize(TextWriter textWriter)
		{
			JsonWriter jsonWriter = new JsonTextWriter(textWriter);
			jsonWriter.Formatting = Formatting.Indented;
			jsonWriter.WriteStartObject();

			if (ExtensionsUsed != null && ExtensionsUsed.Count > 0)
			{
				jsonWriter.WritePropertyName("extensionsUsed");
				jsonWriter.WriteStartArray();
				foreach (var extension in ExtensionsUsed)
				{
					jsonWriter.WriteValue(extension);
				}
				jsonWriter.WriteEndArray();
			}

			if (ExtensionsRequired != null && ExtensionsRequired.Count > 0)
			{
				jsonWriter.WritePropertyName("extensionsRequired");
				jsonWriter.WriteStartArray();
				foreach (var extension in ExtensionsRequired)
				{
					jsonWriter.WriteValue(extension);
				}
				jsonWriter.WriteEndArray();
			}

			if (Accessors != null && Accessors.Count > 0)
			{
				jsonWriter.WritePropertyName("accessors");
				jsonWriter.WriteStartArray();
				foreach (var accessor in Accessors)
				{
					accessor.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Animations != null && Animations.Count > 0)
			{
				jsonWriter.WritePropertyName("animations");
				jsonWriter.WriteStartArray();
				foreach (var animation in Animations)
				{
					animation.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			jsonWriter.WritePropertyName("asset");
			Asset.Serialize(jsonWriter);

			if (Buffers != null && Buffers.Count > 0)
			{
				jsonWriter.WritePropertyName("buffers");
				jsonWriter.WriteStartArray();
				foreach (var buffer in Buffers)
				{
					buffer.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (BufferViews != null && BufferViews.Count > 0)
			{
				jsonWriter.WritePropertyName("bufferViews");
				jsonWriter.WriteStartArray();
				foreach (var bufferView in BufferViews)
				{
					bufferView.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Cameras != null && Cameras.Count > 0)
			{
				jsonWriter.WritePropertyName("cameras");
				jsonWriter.WriteStartArray();
				foreach (var camera in Cameras)
				{
					camera.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Images != null && Images.Count > 0)
			{
				jsonWriter.WritePropertyName("images");
				jsonWriter.WriteStartArray();
				foreach (var image in Images)
				{
					image.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Materials != null && Materials.Count > 0)
			{
				jsonWriter.WritePropertyName("materials");
				jsonWriter.WriteStartArray();
				foreach (var material in Materials)
				{
					material.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Meshes != null && Meshes.Count > 0)
			{
				jsonWriter.WritePropertyName("meshes");
				jsonWriter.WriteStartArray();
				foreach (var mesh in Meshes)
				{
					mesh.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Nodes != null && Nodes.Count > 0)
			{
				jsonWriter.WritePropertyName("nodes");
				jsonWriter.WriteStartArray();
				foreach (var node in Nodes)
				{
					node.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Samplers != null && Samplers.Count > 0)
			{
				jsonWriter.WritePropertyName("samplers");
				jsonWriter.WriteStartArray();
				foreach (var sampler in Samplers)
				{
					sampler.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Scene != null)
			{
				jsonWriter.WritePropertyName("scene");
				Scene.Serialize(jsonWriter);
			}

			if (Scenes != null && Scenes.Count > 0)
			{
				jsonWriter.WritePropertyName("scenes");
				jsonWriter.WriteStartArray();
				foreach (var scene in Scenes)
				{
					scene.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Skins != null && Skins.Count > 0)
			{
				jsonWriter.WritePropertyName("skins");
				jsonWriter.WriteStartArray();
				foreach (var skin in Skins)
				{
					skin.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			if (Textures != null && Textures.Count > 0)
			{
				jsonWriter.WritePropertyName("textures");
				jsonWriter.WriteStartArray();
				foreach (var texture in Textures)
				{
					texture.Serialize(jsonWriter);
				}
				jsonWriter.WriteEndArray();
			}

			base.Serialize(jsonWriter);

			jsonWriter.WriteEndObject();
		}
	}
}
