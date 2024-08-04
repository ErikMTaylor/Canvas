namespace Library_Canvas.DTO {
    public class ContentItemDTO{
        public string Name {get; set;}
        public string Description {get; set;}
        //public string Path{get; set;}
        public string Id {get; set;}
        public string ModuleId{get; set;}
        public string CourseId{get; set;}

        public ContentItemDTO(){
            Name = string.Empty;
            Description = string.Empty;
            //Path = string.Empty;
            Id = string.Empty;
            ModuleId = string.Empty;
            CourseId = string.Empty;
        }
        public override string ToString(){
            return $"{Name} - {Description}\n";
        }
    }
}