using System.Runtime.Serialization;

namespace GLTF.Schema
{
	/// <summary>
	/// A buffer points to binary geometry, animation, or skins.
	/// </summary>
	[DataContract]
	public class Buffer : GLTFChildOfRootProperty
	{
		/// <summary>
		/// The uri of the buffer.
		/// Relative paths are relative to the .gltf file.
		/// Instead of referencing an external file, the uri can also be a data-uri.
		/// </summary>
		[DataMember(Name = "uri")]
		public string Uri;

		/// <summary>
		/// The length of the buffer in bytes.
		/// <minimum>0</minimum>
		/// </summary>
		[DataMember(Name = "byteLength")]
		public int ByteLength;

		public Buffer()
		{
		}

		public Buffer(Buffer buffer, GLTFRoot gltfRoot) : base(buffer, gltfRoot)
		{
			if (buffer == null) return;
			Uri = buffer.Uri;
			ByteLength = buffer.ByteLength;
		}
	}
}
