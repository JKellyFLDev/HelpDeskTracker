namespace LeafFilter.HelpDesk.Model.Base
{
    public interface ITypeEntity : IConditionEntity
    {        
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
