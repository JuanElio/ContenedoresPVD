namespace App.ModelDto.Commons
{
    public class ResponsePaginado<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public IEnumerable<ResponseError>? Errors { get; set; }
        public int? TotalPaginas { get; set; }
        public int? TotalRegistros { get; set; }
    }

    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public IEnumerable<ResponseError>? Errors { get; set; }
       
    }

    //public class ResponseUpload
    //{
    //    public bool Ok { get; set; }
    //    public string? FileName { get; set; }
    //    public string? Extension { get; set; }
    //    public decimal FileSize { get; set; }
    //}

    public class ResponseError
    {
        public string? PropertyName { get; set; }
        public string? ErrorMessage { get; set; }
    }

    //public class ResponseCBX
    //{
    //    public int Id { get; set; }
    //    public string? Descripcion { get; set; }
    //}

    //public class ResponseSaveChanges
    //{
    //    public int UltimoId { get; set; }
    //    public string? Mensaje { get; set; }
    //    public int Ok { get; set; }
    //}
    //public class ResponseStringCBX
    //{
    //    public string Id { get; set; }
    //    public string? Descripcion { get; set; }
    //}
    //public class ResponseStringTdocCCBX
    //{
    //    public string Id { get; set; }
    //    public string? Desc_Corta { get; set; }
    //    public string? Desc_Larga { get; set; }
    //    public string? Longitud { get; set; }
    //}
    //public class ResponseStringModulosCCBX
    //{
    //    public string Id { get; set; }
    //    public string? Descripcion { get; set; }
    //    public string? Orden { get; set; }
    //    public string? Nivel { get; set; }
    //}
    //public class ResponseUbigeoCBX
    //{
    //    public string Id { get; set; }
    //    public string? Descripcion { get; set; }
    //}

}
