using Chebureck.Objects.ScriptableObjects;
using Chebureck.Settings;

namespace Chebureck.Objects.IObjects
{
    public class IObject : BaseInteractableObjects
    {
        public int ObjectID { get; private set; }
        public int UniqueObjectID { get; private set; }
        public IObjectTypeEnumerators Type { get; private set; }

        public override void Init(IObjectInfo info)
        {
            base.Init(info);
            ObjectID = info.id;
            Type = info.type;

            UniqueObjectID = UnityEngine.Random.Range(0, Settings.AppConstants.MAX_ITEMS_ON_SCENE * 2);

            string name = Type == IObjectTypeEnumerators.Item ? "IObjectBasic_" :
                         (Type == IObjectTypeEnumerators.PermanentBooster ? "IObjectPermanentBooster_" :
                         (Type == IObjectTypeEnumerators.TimeBooster ? "IObjectTimeBooster_" : "Unknown"));

            _selfObject.name = $"{name}[{ObjectID}] - [{UniqueObjectID}]";
        }
    }
}