using System.Runtime.Serialization;

namespace GLTF.Schema
{
	[DataContract]
	public class AccessorSparseValues : GLTFProperty
	{
		/// <summary>
		/// The index of the bufferView with sparse values.
		/// Referenced bufferView can't have ARRAY_BUFFER or ELEMENT_ARRAY_BUFFER target.
		/// </summary>
		[DataMember(Name = "bufferView")]
		public BufferViewId BufferView;

		/// <summary>
		/// The offset relative to the start of the bufferView in bytes. Must be aligned.
		/// <minimum>0</minimum>
		/// </summary>
		[DataMember(Name = "byteOffset")]
		public int ByteOffset = 0;

		public AccessorSparseValues()
		{
		}

		public AccessorSparseValues(AccessorSparseValues accessorSparseValues, GLTFRoot gltfRoot) : base(accessorSparseValues)
		{
			if (accessorSparseValues == null) return;

			BufferView = new BufferViewId(accessorSparseValues.BufferView, gltfRoot);
			ByteOffset = accessorSparseValues.ByteOffset;
		}
	}
}
