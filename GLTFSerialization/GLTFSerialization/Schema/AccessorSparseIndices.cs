using System.Runtime.Serialization;

namespace GLTF.Schema
{
	[DataContract]
	public class AccessorSparseIndices : GLTFProperty
	{
		/// <summary>
		/// The index of the bufferView with sparse indices.
		/// Referenced bufferView can't have ARRAY_BUFFER or ELEMENT_ARRAY_BUFFER target.
		/// </summary>
		[DataMember(Name = "bufferView")]
		public BufferViewId BufferView;

		/// <summary>
		/// The offset relative to the start of the bufferView in bytes. Must be aligned.
		/// <minimum>0</minimum>
		/// </summary>
		[DataMember(Name = "byteOffset")]
		public int ByteOffset;

		/// <summary>
		/// The indices data type. Valid values correspond to WebGL enums:
		/// `5121` (UNSIGNED_BYTE)
		/// `5123` (UNSIGNED_SHORT)
		/// `5125` (UNSIGNED_INT)
		/// </summary>
		[DataMember(Name = "componentType")]
		public GLTFComponentType ComponentType;

		public AccessorSparseIndices()
		{
		}

		public AccessorSparseIndices(AccessorSparseIndices accessorSparseIndices, GLTFRoot gltfRoot) : base(accessorSparseIndices)
		{
			if (accessorSparseIndices == null) return;
			
			BufferView = new BufferViewId(accessorSparseIndices.BufferView, gltfRoot);
			ByteOffset = accessorSparseIndices.ByteOffset;
			ComponentType = accessorSparseIndices.ComponentType;
		}
	}
}
