namespace Velocity.Data.Enums
{
    /// <summary>
    /// Represents the state in transit for a given <see cref="Container"/>.
    /// </summary>
    public enum TransitState
    {
        /// <summary>
        /// The container is ready to be driven by the driver.
        /// </summary>
        Ready,

        /// <summary>
        /// Currently driving the truck to transport the container.
        /// </summary>
        InTransit,

        /// <summary>
        /// The driver has successfully delivered the container to client location.
        /// </summary>
        Delivered
    }
}
