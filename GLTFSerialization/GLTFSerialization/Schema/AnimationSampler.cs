using GLTF.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace GLTF.Schema
{
	public enum InterpolationType
	{
		LINEAR,
		STEP,
		CATMULLROMSPLINE,
		CUBICSPLINE
	}

	/// <summary>
	/// Combines input and output accessors with an interpolation algorithm to define a keyframe graph (but not its target).
	/// </summary>
	[DataContract]
	public class AnimationSampler : GLTFProperty
	{
		/// <summary>
		/// The index of an accessor containing keyframe input values, e.G., time.
		/// That accessor must have componentType `FLOAT`. The values represent time in
		/// seconds with `time[0] >= 0.0`, and strictly increasing values,
		/// i.e., `time[n + 1] > time[n]`
		/// </summary>
		[DataMember(Name = "input")]
		public AccessorId Input;

		/// <summary>
		/// Interpolation algorithm. When an animation targets a node's rotation,
		/// and the animation's interpolation is `\"LINEAR\"`, spherical linear
		/// interpolation (slerp) should be used to interpolate quaternions. When
		/// interpolation is `\"STEP\"`, animated value remains constant to the value
		/// of the first point of the timeframe, until the next timeframe.
		/// </summary>
		[DataMember(Name = "interpolation")]
		public InterpolationType Interpolation;

		/// <summary>
		/// The index of an accessor, containing keyframe output values. Output and input
		/// accessors must have the same `count`. When sampler is used with TRS target,
		/// output accessor's componentType must be `FLOAT`.
		/// </summary>
		[DataMember(Name = "output")]
		public AccessorId Output;

		public AnimationSampler()
		{
		}

		public AnimationSampler(AnimationSampler animationSampler, GLTFRoot gltfRoot) : base(animationSampler)
		{
			if (animationSampler == null) return;

			Input = new AccessorId(animationSampler.Input, gltfRoot);
			Interpolation = animationSampler.Interpolation;
			Output = new AccessorId(animationSampler.Output, gltfRoot);
		}

		public static AnimationSampler Deserialize(GLTFRoot root, JsonReader reader)
		{
			var animationSampler = new AnimationSampler();

			while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
			{
				var curProp = reader.Value.ToString();

				switch (curProp)
				{
					case "interpolation":
						animationSampler.Interpolation = reader.ReadStringEnum<InterpolationType>();
						break;
				}
			}

			return animationSampler;
		}
	}
}
