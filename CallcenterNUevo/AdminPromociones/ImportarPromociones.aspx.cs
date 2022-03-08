using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using Negocio;
using Datos;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class ImportarPromociones : System.Web.UI.Page
    {
        public static string CnnPruebas = "ConnectionStringTest";
        public static string CnnProductivo = "ConnectionStringProd";
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(btnCargar);
        }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (ValidaPromociones())
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.ImportarPromociones", "btnCargar_Click", "Inicio de Carga", this.User.Identity.Name.ToString(), null);
                ImportaLayout();
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.ImportarPromociones", "btnCargar_Click", "Fin de Carga", this.User.Identity.Name.ToString(), null);
            }
        }
        protected void btnCanclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        private bool ValidaPromociones()
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            ModPromocionesNoIniciadas campos = new ModPromocionesNoIniciadas();
            ModPromocionesDENoIniciadas campos2 = new ModPromocionesDENoIniciadas();
            ModValidaPromocion cmp = new ModValidaPromocion();
            string file = "";
            bool blnRespuesta = true;
            bool blnEsValidoArchivo = true;
            string extension = "";

            if (string.IsNullOrWhiteSpace(fupPromociones.FileName.ToString()))
            {
                Mensajes("Imposible continuar, debé proporcionar un archivo");
                return false;
            }

            extension = Path.GetExtension(fupPromociones.FileName.ToString());
            if (extension != ".xlsx")
            {
                Mensajes("Imposible continuar, archivo invalido.");
                return false;
            }

            //directorios
            string savePath = @"c:\temp\uploads\";
            //valida existencia de directorio
            if (!Directory.Exists(savePath))
            {//crea directorio
                Directory.CreateDirectory(savePath);
            }
            //ruta y nombre de archivo
            savePath += fupPromociones.FileName;

            //valida existencia de archivo
            if (File.Exists(savePath))
            {
                //Elimina archivo existente
                File.Delete(savePath);
            }

            //guarda archivo en ruta
            fupPromociones.SaveAs(savePath);
            file = savePath;

            //usamos el objeto FileStream para recuperar el archivo
            SLDocument sl;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Creamos el obejto SLDocument para cargar el archivo Excel
                sl = new SLDocument(fs);
                fs.Close();
                fs.Dispose();
                File.Delete(savePath);
            }
            //promociones excel fila 2
            int rowIndex = 2;

            if (sl.GetCellValueAsString(1, 1) != "IdTipoAcumulacion" && sl.GetCellValueAsString(1, 2) != "IdSegmento" && sl.GetCellValueAsString(1, 3) != "IdTipoPromocion")
            {
                blnEsValidoArchivo = false;
            }
            else
            {
                blnEsValidoArchivo = true;
            }


            if (!blnEsValidoArchivo && sl.GetCellValueAsString(1, 1) != "IdTipoPromocion" && sl.GetCellValueAsString(1, 2) != "CodigoInterno" && sl.GetCellValueAsString(1, 3) != "Cantidad")
            {
                blnEsValidoArchivo = false;
            }
            else
            {
                blnEsValidoArchivo = true;
            }

            if (!blnEsValidoArchivo)
            {
                sl.Dispose();
                Mensajes("El archivo proporcionado no cuenta con el layout esperado, ¡Verifique e intente de nuevo!");
                return false;
            }

            if (sl.GetCellValueAsString(1, 3).ToString().Equals("IdTipoPromocion"))
            {//A+A, A+B, A+$ y M&M
                try
                {

                    //promociones excel fila 2
                    rowIndex = 2;

                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(rowIndex, 1)))
                    {
                        campos.IdTipoAcumulacion = Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 1));
                        campos.CodigoInterno = sl.GetCellValueAsString(rowIndex, 4).ToString();
                        campos.FechaInicio = sl.GetCellValueAsString(rowIndex, 9).ToString() + " 00:00:00";
                        campos.FechaFin = sl.GetCellValueAsString(rowIndex, 10).ToString() + " 23:59:59";

                        //Valida existencia de promociones===================================================================================================================
                        int intResultado = 0;

                        cmp.CodigoInterno = campos.CodigoInterno;
                        cmp.FechaInicio = campos.FechaInicio;
                        cmp.FechaFin = campos.FechaFin;
                        cmp.IdTipoacumulacion = campos.IdTipoAcumulacion;

                        intResultado = Ejecuta.ValidaPromocion(CnnProductivo, cmp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar, código interno: " + cmp.CodigoInterno + "  ya existe en alguna mecánica ligada en ambiente productivo.");
                            blnRespuesta = false;
                        }
                        intResultado = Ejecuta.ValidaPromocion(CnnPruebas, cmp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar, código interno: " + cmp.CodigoInterno + "  ya existe en alguna mecánica ligada en ambiente de pruebas.");
                            blnRespuesta = false;
                        }
                        //Fin Valida existencia de promociones===================================================================================================================

                        //incrementamos una unidad al indice de la fila para continuar con el recorrido
                        rowIndex += 1;
                    }
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.ImportarPromociones", "ValidaPromociones()", "Ejecuta.ValidaPromocion(" + CnnProductivo + "," + cmp + ")", "Ocurrio un error, (A+A, A+B , A+$ y M&M):", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al validar la carga  masiva (A+A, A+B , A+$ y M&M) promociones., contacte al administrador");
                }
                //===========================================================================================================================================//
            }
            else if (sl.GetCellValueAsString(1, 1).ToString().Equals("IdTipoPromocion"))
            {//$ y %
                try
                {
                    //Obtiene ruta desde el fileupload
                    savePath = @"c:\temp\uploads\";
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    savePath += fupPromociones.FileName;
                    if (File.Exists(savePath))
                    {
                        File.Delete(savePath);
                    }
                    fupPromociones.SaveAs(savePath);
                    file = savePath;

                    SLDocument sl2;
                    //usamos el objeto FileStream para recuperar el archivo
                    using (FileStream fs2 = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        //Creamos el obejto SLDocument para cargar el archivo Excel
                        sl2 = new SLDocument(fs2);
                        fs2.Close();
                        fs2.Dispose();
                        File.Delete(savePath);
                    }
                    //promociones excel fila 2
                    int rowIndex2 = 2;

                    if (string.IsNullOrEmpty(sl2.GetCellValueAsString(rowIndex2, 1)) && string.IsNullOrEmpty(sl2.GetCellValueAsString(rowIndex2, 2)))
                    {
                        sl2.Dispose();

                        Mensajes("El archivo proporcionado no cuenta con el layout esperado, ¡Verifique e intente de nuevo!");
                        return false;
                    }

                    while (!string.IsNullOrEmpty(sl2.GetCellValueAsString(rowIndex2, 1)))
                    {
                        campos2.CodigoInterno = sl2.GetCellValueAsString(rowIndex2, 2).ToString();
                        campos2.FechaInicio = sl2.GetCellValueAsString(rowIndex2, 5).ToString() + " 00:00:00";
                        campos2.FechaFin = sl2.GetCellValueAsString(rowIndex2, 6).ToString() + " 23:59:59";

                        //Valida existencia de promociones===================================================================================================================
                        int intResultado = 0;

                        cmp.CodigoInterno = campos2.CodigoInterno;
                        cmp.FechaInicio = campos2.FechaInicio;
                        cmp.FechaFin = campos2.FechaFin;
                        cmp.IdTipoacumulacion = 2;

                        intResultado = Ejecuta.ValidaPromocion(CnnProductivo, cmp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar, código interno: " + cmp.CodigoInterno + "  ya existe en alguna mecánica ligada en ambiente productivo.");
                            blnRespuesta = false;
                        }
                        intResultado = Ejecuta.ValidaPromocion(CnnPruebas, cmp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar, código interno: " + cmp.CodigoInterno + "  ya existe en alguna mecánica ligada en ambiente de pruebas.");
                            blnRespuesta = false;
                        }
                        //Fin Valida existencia de promociones===================================================================================================================

                        //incrementamos una unidad al indice de la fila para continuar con el recorrido
                        rowIndex2 += 1;
                    }
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.ImportarPromociones", "ValidaPromociones()", "Ejecuta.ValidaPromocion(" + CnnProductivo + "," + cmp + ")", "Ocurrio un error, ($ y/o %):", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al validar la carga  masiva ($ y/o %) promociones., contacte al administrador");
                }
                //===========================================================================================================================================//
            }

            return blnRespuesta;
        }
        private void ImportaLayout()
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            ModDatosGrid Resultado = new ModDatosGrid();
            string file = "";
            string strCodInt = "";
            string strCodEnt = "";
            bool blnRespuesta = false;
            int intIdlab = 0;
            int rowIndex = 2;
            string anio = "";
            string mes = "";
            string dia = "";
            string savePath = @"c:\temp\uploads\";

            //Valida existencia de directorio
            if (!Directory.Exists(savePath))
            {
                //crea directorio
                Directory.CreateDirectory(savePath);
            }
            //Arma ruta y nom de archivo
            savePath += fupPromociones.FileName;

            //valida existencia de archivo
            if (File.Exists(savePath))
            {
                //elimina archivo existente
                File.Delete(savePath);
            }

            //guarda archivo en ruta especifica
            fupPromociones.SaveAs(savePath);
            file = savePath;

            //usamos el objeto FileStream para recuperar el archivo
            SLDocument sl;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Creamos el obejto SLDocument para cargar el archivo Excel
                sl = new SLDocument(fs);
                fs.Close();
                fs.Dispose();
                File.Delete(savePath);
            }
            //promociones excel fila 2
            rowIndex = 2;

            //valida si la columna IdTipoPromocion existe en la columna #3 ===>A+A,A+B,A+$ y M&M
            if (sl.GetCellValueAsString(1, 3).ToString().Equals("IdTipoPromocion"))
            {//A+A, A+B, A+$ y M&M
                try
                {
                    //recorremos el objeto SQLDocument mediante un ciclo While
                    //concatena los codigos internos delimitados por una coma, M&M
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(rowIndex, 1)))
                    {
                        if (strCodInt == "")
                        {
                            strCodInt = sl.GetCellValueAsString(rowIndex, 4).ToString();
                        }
                        else
                        {
                            if (strCodInt.IndexOf(sl.GetCellValueAsString(rowIndex, 4).ToString()) == -1)
                            {
                                strCodInt = strCodInt + "," + sl.GetCellValueAsString(rowIndex, 4).ToString();
                            }
                        }

                        if (strCodEnt == "")
                        {
                            strCodEnt = sl.GetCellValueAsString(rowIndex, 5).ToString();
                        }
                        else
                        {
                            if (strCodEnt.IndexOf(sl.GetCellValueAsString(rowIndex, 5).ToString()) == -1)
                            {
                                strCodEnt = strCodEnt + "," + sl.GetCellValueAsString(rowIndex, 5).ToString();
                            }
                        }
                        rowIndex += 1;
                    }//Fin concatena código interno

                    //promociones excel fila 2
                    rowIndex = 2;

                    //==================================================================================================================================================================================
                    //valida los laboratorios contenidos en el archivo, si son validos continuara con la carga masiva, en caso contrario
                    //abortara el proceso y el usuario deberá correjir su información e intentar de nuevo.
                    while (!string.IsNullOrWhiteSpace(sl.GetCellValueAsString(rowIndex, 1)))
                    {
                        intIdlab = Ejecuta.ValidarLaboratoriosCargaMasivaPromociones(CnnPruebas, sl.GetCellValueAsString(rowIndex, 16).ToString());
                        if (intIdlab == 0)//Si no existe el laboratorio
                        {
                            Resultado = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, sl.GetCellValueAsString(rowIndex, 4).ToString());
                            if (Resultado != null)
                            {
                                Mensajes("El laboratorio: >>" + sl.GetCellValueAsString(rowIndex, 16).ToString().ToUpper() + " << del producto: " + Resultado.nombreProducto + ",  no es valido, (fila: " + rowIndex + "), verifique e intente de nuevo.");
                            }
                            else
                            {
                                Mensajes("El laboratorio: >>" + sl.GetCellValueAsString(rowIndex, 16).ToString().ToUpper() + " << del producto: " + Limpiastring(sl.GetCellValueAsString(rowIndex, 6).ToString()) + ",  no es valido, (fila: " + rowIndex + "), verifique e intente de nuevo.");
                            }
                            return;
                        }
                        //incrementamos una unidad al indice de la fila para continuar con el recorrido
                        rowIndex += 1;
                    }
                    //==================================================================================================================================================================================


                    //Continua con el proceso de carga masiva despues de que la validación de laboratorios resulte exitosa.
                    rowIndex = 2;
                    while (!string.IsNullOrWhiteSpace(sl.GetCellValueAsString(rowIndex, 1)))
                    {
                        ModPromocionesNoIniciadas campos = new ModPromocionesNoIniciadas();
                        //tipo de promoción seleccionada
                        if (Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 3)) == 1 || Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 3)) == 2)
                        {    //A+A y A+B
                            Resultado = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, sl.GetCellValueAsString(rowIndex, 4).ToString());
                            if (Resultado != null)
                            {
                                //concatenara el nombre resultado de la consulta
                                campos.NombrePromocion = sl.GetCellValueAsString(rowIndex, 13).ToString() + "+" + sl.GetCellValueAsString(rowIndex, 14).ToString() + " " + Limpiastring(Resultado.nombreProducto);
                            }
                            else
                            {//concatenara el nombre contenido en el archivo excel
                                campos.NombrePromocion = sl.GetCellValueAsString(rowIndex, 13).ToString() + "+" + sl.GetCellValueAsString(rowIndex, 14).ToString() + " " + Limpiastring(sl.GetCellValueAsString(rowIndex, 6).ToString());
                            }
                        }
                        else if (Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 3)) == 3 || Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 3)) == 4)
                        {
                            campos.NombrePromocion = Limpiastring(sl.GetCellValueAsString(rowIndex, 6).ToString());
                        }

                        campos.IdTipoAcumulacion = Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 1));
                        campos.IdSegmento = Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 2));
                        campos.IdTipoPromocion = Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 3));
                        campos.CodigoInterno = sl.GetCellValueAsString(rowIndex, 4).ToString();//strCodInt;
                        campos.CodigoInternoEntrega = sl.GetCellValueAsString(rowIndex, 5).ToString();//strCodEnt;
                        campos.IdPeriodo = Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 7).ToString());
                        campos.Limite = Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 8).ToString());

                        campos.FechaInicio = sl.GetCellValueAsString(rowIndex, 9).ToString() + " 00:00:00";
                        campos.FechaFin = sl.GetCellValueAsString(rowIndex, 10).ToString() + " 23:59:59";
                        campos.FechaConteo = sl.GetCellValueAsString(rowIndex, 11).ToString() + " 00:00:00";
                        campos.Comentarios = sl.GetCellValueAsString(rowIndex, 12).ToString();
                        campos.Usuario = HttpContext.Current.User.Identity.Name;
                        campos.CantidadCompra = (string.IsNullOrWhiteSpace(sl.GetCellValueAsString(rowIndex, 13).ToString()) ? 0 : Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 13).ToString()));
                        campos.CantidadEntrega = (string.IsNullOrWhiteSpace(sl.GetCellValueAsString(rowIndex, 14).ToString()) ? 0 : Convert.ToInt32(sl.GetCellValueAsString(rowIndex, 14).ToString()));
                        if (!string.IsNullOrWhiteSpace(sl.GetCellValueAsString(rowIndex, 15).ToString()))
                        {//asigna valor del layout
                            campos.Lider = sl.GetCellValueAsString(rowIndex, 15).ToString();
                        }
                        else
                        { //asignamos el mismo código interno
                            campos.Lider = sl.GetCellValueAsString(rowIndex, 4).ToString();
                        }
                        campos.Laboratorio = sl.GetCellValueAsString(rowIndex, 16).ToString(); ///Laboratorio
                        campos.VerEnReporte = 1;

                        //Guarda nueva promoción
                        blnRespuesta = Ejecuta.GuardarPromociones(CnnPruebas, campos);


                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //Asocia laboratorios
                        ModsetNvasPromLaboratorio cmpLab = new ModsetNvasPromLaboratorio();
                        cmpLab.CodigoInterno = campos.CodigoInterno;
                        cmpLab.IdLaboratorio = Ejecuta.ValidarLaboratoriosCargaMasivaPromociones(CnnPruebas, campos.Laboratorio);

                        //Se asocia laboratorio indicando el código interno
                        Ejecuta.GuardarnvoLaboratorio(CnnPruebas, cmpLab);
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        //incrementamos una unidad al indice de la fila para continuar con el recorrido
                        rowIndex += 1;
                    }
                    Mensajes("La carga masiva de promociones ha finalizado correctamente.");
                    sl.Dispose();
                    fupPromociones.Focus();
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.ImportarPromociones", "ImportaLayout()", "Ejecuta.GuardarPromociones(" + CnnPruebas + ",campos)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al Intentar cargar de forma masiva (A+A, A+B , A+$ y M&M) promociones, contacte al administrador");
                }
                //===========================================================================================================================================//
            }
            //valida si la columna IdTipoPromocion existe en la columna #1 ===>$ y %
            else if (sl.GetCellValueAsString(1, 1).ToString().Equals("IdTipoPromocion"))
            {//$ y %
                try
                {

                    //Obtiene ruta desde el fileupload
                    savePath = @"c:\temp\uploads\";
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    savePath += fupPromociones.FileName;
                    if (File.Exists(savePath))
                    {
                        File.Delete(savePath);
                    }
                    fupPromociones.SaveAs(savePath);
                    file = savePath;

                    SLDocument sl2;
                    //usamos el objeto FileStream para recuperar el archivo
                    using (FileStream fs2 = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        //Creamos el obejto SLDocument para cargar el archivo Excel
                        sl2 = new SLDocument(fs2);
                        fs2.Close();
                        fs2.Dispose();
                        File.Delete(savePath);
                    }
                    //promociones excel fila 2
                    int rowIndex2 = 2;


                    while (!string.IsNullOrWhiteSpace(sl2.GetCellValueAsString(rowIndex2, 1)))
                    {
                        ModPromocionesDENoIniciadas campos2 = new ModPromocionesDENoIniciadas();
                        strCodInt = sl2.GetCellValueAsString(rowIndex2, 2).ToString();
                        campos2.IdTipoPromocion = Convert.ToInt32(sl2.GetCellValueAsString(rowIndex2, 1));
                        campos2.CodigoInterno = strCodInt;
                        campos2.Cantidad = (string.IsNullOrWhiteSpace(sl2.GetCellValueAsString(rowIndex2, 3).ToString()) ? 0 : float.Parse(sl2.GetCellValueAsString(rowIndex2, 3).ToString()));
                        campos2.NombreMecanica = Limpiastring(sl2.GetCellValueAsString(rowIndex2, 4).ToString());
                        campos2.FechaInicio = sl2.GetCellValueAsString(rowIndex2, 5).ToString() + " 00:00:00";
                        campos2.FechaFin = sl2.GetCellValueAsString(rowIndex2, 6).ToString() + " 23:59:59";
                        campos2.Comentarios = sl2.GetCellValueAsString(rowIndex2, 7).ToString();
                        campos2.Usuario = HttpContext.Current.User.Identity.Name;
                        campos2.VerEnReporte = 1;

                        blnRespuesta = Ejecuta.GuardarPromocionesDEPorc(CnnPruebas, campos2);
                        //incrementamos una unidad al indice de la fila para continuar con el recorrido
                        rowIndex2 += 1;
                    }

                    Mensajes("La carga masiva de promociones ha finalizado correctamente.");
                    sl2.Dispose();
                    fupPromociones.Focus();
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.ImportarPromociones", "ImportaLayout()", "Ejecuta.GuardarPromociones(" + CnnPruebas + ",campos)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al Intentar cargar de forma masiva ($, %) promociones., contacte al administrador");
                }
                //===========================================================================================================================================//
            }
        }
        private string Limpiastring(string strvalor)
        {
            string strResultado = "";
            string strCaracter1 = "";

            for (int i = 0; i <= (strvalor.Length - 1); i++)
            {
                switch (strvalor.Substring(i, 1))
                {
                    case "'":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ",":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ".":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "\\":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "@":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "|":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "#":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "?":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "&":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "<":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ">":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ";":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "*":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "=":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "{":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "}":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "!":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "¿":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "¡":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ":":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "[":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "]":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "//":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "°":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "á":
                        strCaracter1 = strCaracter1 + "a";
                        break;
                    case "é":
                        strCaracter1 = strCaracter1 + "e";
                        break;
                    case "í":
                        strCaracter1 = strCaracter1 + "i";
                        break;
                    case "ó":
                        strCaracter1 = strCaracter1 + "o";
                        break;
                    case "ú":
                        strCaracter1 = strCaracter1 + "u";
                        break;
                    case "Á":
                        strCaracter1 = strCaracter1 + "A";
                        break;
                    case "É":
                        strCaracter1 = strCaracter1 + "E";
                        break;
                    case "Í":
                        strCaracter1 = strCaracter1 + "I";
                        break;
                    case "Ó":
                        strCaracter1 = strCaracter1 + "O";
                        break;
                    case "Ú":
                        strCaracter1 = strCaracter1 + "U";
                        break;
                    default:
                        strCaracter1 = strCaracter1 + strvalor.Substring(i, 1).ToString();
                        break;
                }
            }
            strResultado = strCaracter1;

            return strResultado;
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
    }
}