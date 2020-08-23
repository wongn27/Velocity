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
        /// Currently driving the truck to transport the container to the client.
        /// </summary>
        InTransit,

        /// <summary>
        /// The driver has successfully delivered the container to client location.
        /// </summary>
        Delivered,

        /// <summary>
        /// The driver is picking up an empty container that was left at the client location.
        /// </summary>
        PickUpEmpty,

        /// <summary>
        /// The driver has successfully dropped off the empty container
        /// </summary>
        DropOffEmpty
    }
}
