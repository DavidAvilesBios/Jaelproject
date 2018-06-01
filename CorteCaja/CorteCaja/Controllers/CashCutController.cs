using CorteCaja.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorteCaja.Controllers
{
    public class CashCutController : Controller
    {
        adMarissa_Bios_no_le_pEntities _context;
        CashCutViewModels _cashCutVM;
        ReportViewModels _reportVM;

        public CashCutController()
        {
            _cashCutVM = new CashCutViewModels();
            _context = new adMarissa_Bios_no_le_pEntities();
            _reportVM = new ReportViewModels();
        }

        // GET: CashCut
        public ActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public JsonResult BringAgents()
        {

            var agents = _context.TablaUsuarios.ToList();
            return Json(agents);
        }
        public ActionResult Report()
        {
            //var conceptos = _context.admConceptos.ToList();

            //foreach (var concepto in conceptos)
            //{
            //    _reportVM.Cosa = concepto.CANCHOCODIGOALMACEN;
            //    _reportVM.Cosa2 = concepto.CRUTAENTREGA;

            //}

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult BringCatalog(DateTime date,String usuario)
        {
            //var conceptos = _context.admDocumentos.Where(x => x.CIDAGENTE == agentId).ToList();
            
             var conceptos= _context.admDocumentos.Join(_context.admConceptos, doc => doc.CIDCONCEPTODOCUMENTO,
              concept => concept.CIDCONCEPTODOCUMENTO, (doc, concept) => new { DOC = doc, CONCEPT = concept }).Where(docAndconcept=>docAndconcept.DOC.CUSUARIO==usuario && docAndconcept.DOC.CIDPROYECTO!=0).ToList();
            //var conceptos = from doc in _context.admDocumentos
            //                join agente in _context.admConceptos on doc.CIDCONCEPTODOCUMENTO equals agente.CIDCONCEPTODOCUMENTO
            //                 where doc.CIDCONCEPTODOCUMENTO == agentId
            //                 select new { Doc = doc, Agente = agente};
            double? ResultSuma1 = 0;
            var suma1 = _context.admDocumentos.Where(x => x.CUSUARIO == usuario && x.CIDPROYECTO == 1).Where(x => x.CTOTAL!=null);
            
            if (suma1.Any())
            {
                ResultSuma1 = suma1.Sum(x => x.CTOTAL);
            }
            double? ResultSuma2 = 0;
            var suma2 = _context.admDocumentos.Where(x => x.CUSUARIO == usuario && x.CIDPROYECTO == 2).Where(x => x.CTOTAL != null);

            if (suma2.Any())
            {
                ResultSuma2 = suma2.Sum(x => x.CTOTAL);
            }
            double? ResultSuma3 = 0;
            var suma3 = _context.admDocumentos.Where(x => x.CUSUARIO == usuario && x.CIDPROYECTO == 3).Where(x => x.CTOTAL != null);

            if (suma3.Any())
            {
                ResultSuma3 = suma3.Sum(x => x.CTOTAL);
            }
            double? ResultSuma4= 0;
            var suma4 = _context.admDocumentos.Where(x => x.CUSUARIO == usuario && x.CIDPROYECTO == 4).Where(x => x.CTOTAL != null);

            if (suma4.Any())
            {
                ResultSuma4 = suma4.Sum(x => x.CTOTAL);
            }
            double? ResultSuma5 = 0;
            var suma5 = _context.admDocumentos.Where(x => x.CUSUARIO == usuario && x.CIDPROYECTO == 5).Where(x => x.CTOTAL != null);

            if (suma5.Any())
            {
                ResultSuma5 = suma5.Sum(x => x.CTOTAL);
            }

            List<dynamic> Objects = new List<dynamic>
            {
                new { CONCEPT = conceptos},
                new { SUM = ResultSuma1},
                new { SUM2 =ResultSuma2 },
                new {SUM3=ResultSuma3},
                new {SUM4=ResultSuma4},
                new {SUM5=ResultSuma5}

            };

            return Json(Objects);
        }

        public ActionResult TableTest()
        {
            return View();
        }
    }
}