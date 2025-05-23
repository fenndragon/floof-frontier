using Content.Shared.Whitelist;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._NF.Silicons.Borgs;

/// <summary>
/// Uses placeholder entities to give borgs "hands" that are whitelisted for a certain kind of item.
/// The items in it can be dropped and picked up if they match its whitelist.
/// </summary>
[RegisterComponent, NetworkedComponent, Access(typeof(DroppableBorgModuleSystem))]
public sealed partial class DroppableBorgModuleComponent : Component
{
    /// <summary>
    /// The items to spawn in borg hands.
    /// </summary>
    [DataField(required: true)]
    public List<DroppableBorgItem> Items = new();

    /// <summary>
    /// Placeholder items to spawn in borg hands.
    /// The ID 
    /// </summary>
    [DataField]
    public List<DroppableBorgItem> Placeholders = new();

    /// <summary>
    /// The ID of the container to add that stores items when not in hands.
    /// </summary>
    [DataField]
    public string ContainerId = "nf-droppable-items";

    /// <summary>
    /// The ID of the container to add that stores item placeholders when not in hands.
    /// </summary>
    [DataField]
    public string PlaceholderContainerId = "nf-item-placeholders";

    /// <summary>
    /// The ID to check for module equivalence.
    /// </summary>
    [DataField(required: true)]
    public string ModuleId = default!;
}

[DataDefinition]
public sealed partial class DroppableBorgItem
{
    /// <summary>
    /// The entity to spawn (if not a placeholder) and use for the placeholder sprite.
    /// </summary>
    [DataField(required: true)]
    public EntProtoId Id;

    /// <summary>
    /// A whitelist that items must match to be picked up by the placeholder.
    /// Entities must have <c>ItemComponent</c> to be picked up unless the specified ID not not an item.
    /// </summary>
    [DataField(required: true)]
    public EntityWhitelist Whitelist;

    /// <summary>
    /// An optional blacklist that items must not match to be picked up by the placeholder.
    /// </summary>
    [DataField]
    public EntityWhitelist? Blacklist;

    /// <summary>
    /// An optional localization string for the entity name to display for the borg's hands.
    /// </summary>
    [DataField]
    public LocId? DisplayName;
}
