namespace ISEN.DotNet.Library.Models
{
    public abstract class ArchivableEntity : BaseEntity
    {
        public bool Archived { get; set; } = false;

        public void Archive() { Archived = true; }
        public void Restore() { Archived = false; }


    }
}
