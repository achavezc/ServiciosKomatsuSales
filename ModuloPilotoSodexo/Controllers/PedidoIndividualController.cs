using GR.Scriptor.Framework;
using GR.Scriptor.Msc.Memberships.Agente.BL;
using GR.Scriptor.Msc.Memberships.Agente.Response;
using GR.Scriptor.Msc.Memberships.Models;
using ModuloPilotoSodexo.Agente.BL;
using ModuloPilotoSodexo.Proxy;
using RANSA.MCIP.DTO;
using RANSA.MCIP.Entidades.Constantes;
using RANSA.MCIP.LogicaNegocio;
using RANSA.MCIP.ViewModel;
using RANSA.MCIP.ViewModel.Pedidos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GR.Scriptor.Framework;
using ModuloPilotoSodexo.Helper;
using ModuloPilotoSodexo.Models;
using Newtonsoft.Json;


namespace ModuloPilotoSodexo.Controllers
{
    public class PedidoIndividualController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Pedidos/
        public ActionResult Registrar()
        {
            PedidoViewModel pedidoViewModel = Registrar_aux("");
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(pedidoViewModel));
        }
        public ActionResult Consultar()
        {
            ConsultaPedidoViewModel consultaPedidoViewModel = ConsultaPedido_Aux();
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(consultaPedidoViewModel));
        }
        public ActionResult Modificar(string nroPedido)
        {
            PedidoViewModel pedidoViewModel = Registrar_aux(nroPedido);
            //codigo para poblar pedidoViewModel.DatosFormulario
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(pedidoViewModel));
        }

        public ActionResult RegistrarPedidoIndividual(RequestRegistroPedidoIndividualViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var usuario = Helper.HelperCtrl.ObtenerUsuario();
                request.UsuarioRegistro = usuario;
                var response = new PedidoBL().RegistroPedidoIndividual(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        public ActionResult ActualizarPedidoIndividual(RequestRegistroPedidoIndividualViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var usuario = Helper.HelperCtrl.ObtenerUsuario();
                request.UsuarioModificacion = usuario;


                var response = new PedidoBL().ActualizaPedidoIndividual(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        public ActionResult ObtenerDetallePedidoIndividual(string idPedido)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new PedidoBL().ObtenerDetallePedidoIndividual(idPedido);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        public ActionResult EliminarPedidoIndividual(List<EliminarPedidoViewModel> ListaEliminar)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new PedidoBL().EliminarPedidoIndividual(ListaEliminar);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        public ActionResult ValidarPedidoIndividual(string codigoTipoPedido, string codigoCuenta)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new PedidoBL().ObtenerCamposPedido(codigoTipoPedido, codigoCuenta);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }

        public PedidoViewModel Registrar_aux(string nroPedido)
        {
            try
            {
                PedidoViewModel pedidoViewModel = new PedidoViewModel();
                pedidoViewModel.ObjetosFormulario = new PedidosObjetosFormularioViewModel();
                pedidoViewModel.DatosFormulario = new PedidosDatosFormularioViewModel();
                ClienteBL clienteBL = new ClienteBL();
                AlmacenBL almacenBL = new AlmacenBL();
                CuentaBL cuentaBL = new CuentaBL();
                NegocioBL negocioBL = new NegocioBL();
                TipoPedidoBL tipoPedidoBL = new TipoPedidoBL();
                SeguridadBL seguridadBL = new SeguridadBL();

                ResponseUsuarioMscDTO usuario = (ResponseUsuarioMscDTO)Session["usuario"];

                string defaultCodigoCuenta = "";
                string defaultFechaSolicitud = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                string defaultHoraSolicitud = String.Format("{0:HH}", DateTime.Now) + ":" + String.Format("{0:mm}", DateTime.Now);


                var responseListaCliente = clienteBL.ListarCliente();
                var responseListaAlmacen = almacenBL.ListarAlmacen();
                var responseListaCuenta = cuentaBL.ListarCuenta();
                var responseListaTipoPedido = tipoPedidoBL.ListarTipoPedido();
                var responseListaNegocio = negocioBL.ListarNegocio();
                RequestObtenerCuentaPorCliente requestCuenta = new RequestObtenerCuentaPorCliente();
                requestCuenta.CodigoCliente = Session["CodigoCliente"].ToString();

                var responseObtenerCuenta = cuentaBL.ObtenerCuentaPorCliente(requestCuenta);

                //pedidoViewModel.ObjetosFormulario.ListaCodigoCuenta = GenerarListaCuenta(responseListaCuenta.Cuentas);    
                var listaCuentas = GenerarListaCuenta(responseListaCuenta.Cuentas);
                var ListaCuentasPermitidas = (from p in listaCuentas
                                           where (from b in usuario.CuentasPermitidas
                                                  select b)
                                                     .Contains(p.Codigo)
                                           select p).Distinct().ToList();
                pedidoViewModel.ObjetosFormulario.ListaCodigoTipoPedido = GenerarListaTipoPedido(responseListaTipoPedido.TipoPedidos);
                pedidoViewModel.ObjetosFormulario.ListaCodigoCuenta = ListaCuentasPermitidas;
                pedidoViewModel.ObjetosFormulario.ListaCodigoPuntoOrigen = GenerarListaPuntoOrigen(responseListaAlmacen.Almacenes);
                pedidoViewModel.ObjetosFormulario.ListaCodigoPuntoDestino = GenerarListaPuntoDestino(responseListaCliente.Clientes);
                pedidoViewModel.ObjetosFormulario.ListaCodigoNegocio = GenerarListaNegocio(responseListaNegocio.Negocios);
                pedidoViewModel.ObjetosFormulario.ListaPermisos = usuario.Usuario.Permisos;

                defaultCodigoCuenta = responseListaCuenta.DefaultCodigoCuenta;

                if (responseObtenerCuenta.cuenta != null)
                {
                    defaultCodigoCuenta = responseObtenerCuenta.cuenta.CodigoCuenta;
                }

                var responseNumeroPedido = new PedidoBL().ObtenerNumeroPedido();
                pedidoViewModel.DatosFormulario.NroPedido = responseNumeroPedido.Correlativo;

                TipoAccionRegistro tipoAccionRegistro = (String.IsNullOrEmpty(nroPedido) == true ? TipoAccionRegistro.Nuevo : TipoAccionRegistro.Actualizar);
                switch (tipoAccionRegistro)
                {
                    case TipoAccionRegistro.Nuevo:
                        {
                            ViewBag.Titulo = "Registrar Pedido";
                            pedidoViewModel.DatosFormulario.CodigoTipoPedido = responseListaTipoPedido.DefaultCodigoTipoPedido;
                            pedidoViewModel.DatosFormulario.CodigoCuenta = defaultCodigoCuenta;
                            pedidoViewModel.DatosFormulario.CodigoPuntoOrigen = responseListaAlmacen.DefaultCodigoAlmacen;
                            pedidoViewModel.DatosFormulario.CodigoPuntoDestino = responseListaCliente.DefaultCodigoCliente;
                            pedidoViewModel.DatosFormulario.CodigoNegocio = responseListaNegocio.DefaultCodigoNegocio;
                            pedidoViewModel.DatosFormulario.CodigoCliente = requestCuenta.CodigoCliente;
                            pedidoViewModel.DatosFormulario.FechaSolicitud = defaultFechaSolicitud;
                            pedidoViewModel.DatosFormulario.HoraSolicitud = defaultHoraSolicitud;
                            pedidoViewModel.DatosFormulario.Estado = "new";
                            //pedidoViewModel.DatosFormulario.Estado = "pendiente";
                            pedidoViewModel.SoloLectura = false;
                        }
                        break;
                    case TipoAccionRegistro.Actualizar:
                        {
                            ViewBag.Titulo = "Modificar Pedido";

                            pedidoViewModel.SoloLectura = true;
                        }
                        break;
                }

                return pedidoViewModel;
            }
            catch (Exception ex)
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public ConsultaPedidoViewModel ConsultaPedido_Aux()
        {
            try
            {
                ConsultaPedidoViewModel consultapPedidoViewModel = new ConsultaPedidoViewModel();
                consultapPedidoViewModel.ObjetosFormulario = new ConsultaPedidosObjetosFormularioViewModel();
                consultapPedidoViewModel.DatosFormulario = new ConsultaPedidosDatosFormularioViewModel();
                EstadoBL estadoBL = new EstadoBL();
                var responseListaEstado = estadoBL.ListarEstados();
                consultapPedidoViewModel.ObjetosFormulario.ListaEstado = GenerarListaEstado(responseListaEstado.Estados);
                return consultapPedidoViewModel;
            }
            catch (Exception ex)
            {
                (new ManejadorLog()).RegistrarEvento(MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);
                return null;
            }
        }

        private List<ElementoDTO> GenerarListaPuntoDestino(List<ClienteDTO> listaCliente)
        {
            List<ElementoDTO> lista = new List<ElementoDTO>();

            foreach (var item in listaCliente)
            {
                lista.Add(new ElementoDTO()
                {
                    Codigo = item.CodigoCliente,
                    Nombre = item.Nombre,
                    Elemento1 = item.Direccion
                });
            }
            return lista;
        }

        private List<ElementoDTO> GenerarListaPuntoOrigen(List<AlmacenDTO> listaAlmacen)
        {
            List<ElementoDTO> lista = new List<ElementoDTO>();

            foreach (var item in listaAlmacen)
            {
                lista.Add(new ElementoDTO()
                {
                    Codigo = item.CodigoAlmacen,
                    Nombre = item.Nombre,
                    Elemento1 = item.Direccion
                });
            }
            return lista;
        }

        private List<ElementoDTO> GenerarListaCuenta(List<CuentaDTO> listaCuenta)
        {
            List<ElementoDTO> lista = new List<ElementoDTO>();

            foreach (var item in listaCuenta)
            {
                lista.Add(new ElementoDTO()
                {
                    Codigo = item.CodigoCuenta,
                    Nombre = item.Nombre,
                    Elemento1 = item.CodigoNegocio,
                    IdObjeto = item.IdCuenta
                });
            }
            return lista;
        }

        private List<ElementoDTO> GenerarListaTipoPedido(List<TipoPedidoDTO> listaTipoPedido)
        {
            List<ElementoDTO> lista = new List<ElementoDTO>();

            foreach (var item in listaTipoPedido)
            {
                lista.Add(new ElementoDTO()
                {
                    Codigo = item.CodigoTipoPedido,
                    Nombre = item.Descripcion
                });
            }
            return lista;
        }
        private List<ElementoDTO> GenerarListaEstado(List<EstadoDTO> listaEstado)
        {
            List<ElementoDTO> lista = new List<ElementoDTO>();

            foreach (var item in listaEstado)
            {
                lista.Add(new ElementoDTO()
                {
                    Codigo = item.Codigo,
                    Nombre = item.Descripcion
                });
            }
            return lista;
        }

        private List<ElementoDTO> GenerarListaNegocio(List<NegocioDTO> listaNegocio)
        {
            List<ElementoDTO> lista = new List<ElementoDTO>();

            foreach (var item in listaNegocio)
            {
                lista.Add(new ElementoDTO()
                {
                    Codigo = item.CodigoNegocio,
                    Nombre = item.Descripcion,
                    IdObjeto = item.IdNegocio
                });
            }
            return lista;
        }

        public ActionResult RegistrarPedidoDetalle()
        {
            PedidoDetalleViewModel pedidoDetalleViewModel = RegistrarPedidoDetalle_aux(null);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(pedidoDetalleViewModel));
        }

        public ActionResult ModificarPedidoDetalle(int? idPedidoDetalle)
        {
            PedidoDetalleViewModel pedidoDetalleViewModel = RegistrarPedidoDetalle_aux(idPedidoDetalle);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(pedidoDetalleViewModel));
        }

        private PedidoDetalleViewModel RegistrarPedidoDetalle_aux(int? idPedidoDetalle)
        {
            PedidoDetalleViewModel pedidoDetalleViewModel = new PedidoDetalleViewModel();

            TipoAccionRegistro tipoAccionRegistro = (idPedidoDetalle.HasValue == false ? TipoAccionRegistro.Nuevo : TipoAccionRegistro.Actualizar);
            switch (tipoAccionRegistro)
            {
                case TipoAccionRegistro.Nuevo:
                    {
                        pedidoDetalleViewModel.Datos.IdPedidoDetalle = null;
                        pedidoDetalleViewModel.Datos.EstadoRegistro = "1";
                    }
                    break;
                case TipoAccionRegistro.Actualizar:
                    {
                        pedidoDetalleViewModel.Datos.IdPedidoDetalle = idPedidoDetalle;
                    }
                    break;
            }

            return pedidoDetalleViewModel;
        }
        //
        // GET: /Pedidos/
        public ActionResult ConsultarPedidos(RequestBusquedaPedidosViewModel filtros, string requestExportar, PaginacionDTO paginacionDTO)
        {
            ActionResult actionResult = null;

            var manejadorLogEventos = new ManejadorLogEventos();
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["export"]))
                    {

                        var idGrilla = "";
                        filtros = GR.Scriptor.Framework.Helper.ConvertirJsonAObjeto<RequestBusquedaPedidosViewModel>(requestExportar);
                        if (idGrilla != null) paginacionDTO.IdGrilla = new Guid(idGrilla);
                        paginacionDTO.sord =
                            new HelperDataScriptor().ObtenerCampoOrdenDefault(paginacionDTO.IdGrilla);
                        paginacionDTO.rows = 9999;
                        paginacionDTO.page = 1;
                        var listaRespuesta = new PedidoBL().BusquedaPedidoIndividual(filtros, paginacionDTO);
                        listaRespuesta.NroPagina = 1;
                        actionResult = HelperCtrl.ExportarExcel(listaRespuesta, listaRespuesta.ListaPedidos, paginacionDTO.IdGrilla, "NroPedido", Request.QueryString["export"], Response, "Lista_de_Pedidos_");
                    }
                    else
                    {
                        var listPedidos = new PedidoBL().BusquedaPedidoIndividual(filtros, paginacionDTO);
                        if (listPedidos.Resultado.Satisfactorio)
                        {
                            var totalPages = int.Parse("" + Math.Ceiling(Convert.ToDouble(listPedidos.TotalRegistros) / paginacionDTO.GetNroFilas()));
                            var res = Grid.toJSONFormat2(listPedidos.ListaPedidos, paginacionDTO.GetNroPagina(), listPedidos.TotalRegistros, totalPages, "NroPedido");
                            actionResult = Content(res);
                        }
                        else
                        {
                            actionResult = Content(Grid.toJSONFormat2(listPedidos.ListaPedidos, 0, 0, 0));
                        }
                    }
                }
                else
                {
                    var cadena = string.Empty;
                    var objetos = GR.Scriptor.Framework.Helper.GetErrorsFromModelState(ref cadena, ModelState);
                    actionResult = Content(Grid.emptyStrJSON(cadena, objetos));
                }
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            finally
            {
                manejadorLogEventos.RegistrarTiempoEjecucion(HelperCtrl.ObtenerAtributosManejadorEventos(ControllerContext.ToString(), MethodBase.GetCurrentMethod().Name, HelperCtrl.ObtenerUsuario()));
            }
            return actionResult;
        }

        public ActionResult AgregarAnexos(HttpPostedFileBase userfile, String iddoc)
        {
            AdjuntarArchivosProxyRest proxy = new AdjuntarArchivosProxyRest();
            int maxSize = 5;//MB
            //int.Parse(parametros.Where(x => x.Codigo == (int)TRAMARSA.WA.CM.Entidades.Constantes.ConstantesParametrosSistema.MaxSize).FirstOrDefault().Valor);
            if (userfile.ContentLength <= maxSize * 1024 * 1024)
            {
                var binary = new byte[userfile.ContentLength];
                userfile.InputStream.Read(binary, 0, userfile.ContentLength);

                ResponseAdjuntarArchivoDTO response = proxy.AgregarArchivo(new RequestAdjuntarArchivosDTO()
                {
                    filtros = new AdjuntarArchivosDTO()
                    {
                        archivoStream = binary,
                        filename = userfile.FileName,
                    },
                    //Server = Server,
                    SociedadPropietaria = Helpers.Helper.GetSociedadPropietaria()
                });

                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(response));
            }
            else
            {
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new ResponseAdjuntarArchivoDTO()
                {
                    error = "Fichero demasiado grande",
                    ficheroReal = userfile.FileName,
                    ficheroVisual = userfile.FileName
                }));
            }
        }

        public ActionResult CargaMasivaPedidoIndividual(HttpPostedFileBase upload)
        {
            ActionResult actionResult = null;
            var manejadorLogEventos = new ManejadorLogEventos();
            try
            {
                var response = new PedidoBL().CargarDatosMasivos(upload);
                actionResult = actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            finally
            {
                manejadorLogEventos.RegistrarTiempoEjecucion(HelperCtrl.ObtenerAtributosManejadorEventos(ControllerContext.ToString(), MethodBase.GetCurrentMethod().Name, HelperCtrl.ObtenerUsuario()));
            }
            return actionResult;
        }

        public ActionResult RegistraPedidoIndividualMasivo(RequestRegistroMasivoPedidoIndividualViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var response = new PedidoBL().RegistroMasivoPedidoIndividualMasivo(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {

                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }


            return actionResult;
        }

        public ActionResult CambiarEstadoPedidoIndividual(CambiarEstadoPedidoViewModel request)
        {
            ActionResult actionResult = null;
            try
            {
                var usuario = Helper.HelperCtrl.ObtenerUsuario();
                request.UsuarioModificacion = usuario;
                var response = new PedidoBL().CambiarEstadoPedidoIndivial(request);
                actionResult = Content(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                HelperCtrl.GrabarLog(ex, "", PoliticaExcepcion.WebController);
            }
            return actionResult;
        }
    }
}