import { Routes, withDisabledInitialNavigation, withEnabledBlockingInitialNavigation } from '@angular/router';
import { BrowserUtils } from '@azure/msal-browser';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'centroCategoria', loadChildren: () => import("./centro-categoria/centro-categoria.routes").then(r => r.CENTRO_CATEGORIA_ROUTES) },
  { path: 'centroClasse', loadChildren: () => import("./centro-classe/centro-classe-routes").then(r => r.CENTRO_CLASSE_ROUTES) },
  { path: 'centroCusto', loadChildren: () => import("./centro-custo/centro-custo.routes").then(r => r.CENTRO_CUSTO_ROUTES) },
  { path: 'centroCustoSituacao', loadChildren: () => import("./centro-custo-situacao/centro-custo-situacao.routes").then(r => r.CENTRO_CUSTO_SITUACAO_ROUTES) },
  { path: 'centroCustoUsuario', loadChildren: () => import("./centro-custo-usuario/centro-custo-usuario.routes").then(r => r.CENTRO_CUSTO_USUARIO_ROUTES) },
  { path: 'centroDiretoria', loadChildren: () => import("./centro-diretoria/centro-diretoria.routes").then(r => r.CENTRO_DIRETORIA_ROUTES) },
  { path: 'centroEmpresa', loadChildren: () => import("./centro-empresa/centro-empresa.routes").then(r => r.CENTRO_EMPRESA_ROUTES) },
  { path: 'centroFilial', loadChildren: () => import("./centro-filial/centro-filial.routes").then(r => r.CENTRO_FILIAL_ROUTES) },
  { path: 'centroLucro', loadChildren: () => import("./centro-lucro/centro_lucro.routes").then(r => r.CENTRO_LUCRO_ROUTES) },
  { path: 'centroLucroSituacao', loadChildren: () => import("./centro-lucro-situacao/centro-lucro-situacao.routes").then(r => r.CENTRO_LUCRO_SITUACAO_ROUTES) },
  { path: 'centroLucroUsuario', loadChildren: () => import("./centro-lucro-usuario/centro-lucro-usuario.routes").then(r => r.CENTRO_LUCRO_USUARIO_ROUTES) },
  { path: 'centroStatus', loadChildren: () => import("./centro-status/centro-status.routes").then(r => r.CENTRO_STATUS_ROUTES) },
  { path: 'comboInformacoes', loadChildren: () => import("./combo-informacoes/combo-informacoes.routes").then(r => r.COMBO_INFORMACOES_ROUTES) },
  { path: 'comboSeparador', loadChildren: () => import("./combo-separador/combo-separador.routes").then(r => r.COMBO_SEPARADOR_ROUTES) },
  { path: 'contaContabil', loadChildren: () => import("./conta-contabil/conta-contabil.routes").then(r => r.CONTA_CONTABIL_ROUTES) },
  { path: 'contaContabilClassificacao', loadChildren: () => import("./conta-contabil-classificacao/conta-contabil-classificacao.routes").then(r => r.CONTA_CONTABIL_CLASSIFICACAO_ROUTES) },
  { path: 'contaContabilFormula', loadChildren: () => import("./conta-contabil-formula/conta-contabil-formula.routes").then(r => r.CONTA_CONTABIL_FORMULA_ROUTES) },
  { path: 'exercicio', loadChildren: () => import("./exercicio/exercicio.routes").then(r => r.EXERCICIO_ROUTES) },
  { path: 'funcionario', loadChildren: () => import("./funcionario/funcionario.routes").then(r => r.FUNCIONARIO_ROUTES) },
  { path: 'funcionarioCargo', loadChildren: () => import("./funcionario-cargo/funcionario-cargo.routes").then(r => r.FUNCIONARIO_CARGO_ROUTES) },
  { path: 'funcionarioContratacao', loadChildren: () => import("./funcionario-contratacao/funcionario-contratacao.routes").then(r => r.FUNCIONARIO_CONTRATACAO_ROUTES) },
  { path: 'funcionarioDependente', loadChildren: () => import("./funcionario-dependente/funcionario-dependente.routes").then(r => r.FUNCIONARIO_DEPENDENTE_ROUTES) },
  { path: 'home', loadChildren: () => import("./home/home.routes").then(r => r.HOME_ROUTES) },
  { path: 'lancamentoCentroCusto', loadChildren: () => import("./lancamento-centro-custo/lancamento-centro-custo.routes").then(r => r.LANCAMENTO_CENTRO_CUSTO_ROUTES) },
  { path: 'centroCustoLancamento', loadChildren: () => import("./lancamento-centro-custo/lancamento-centro-custo.routes").then(r => r.LANCAMENTO_CENTRO_CUSTO_ROUTES) },
  { path: 'lancamentoTipo', loadChildren: () => import("./lancamento-tipo/lancamento-tipo.routes").then(r => r.LANCAMENTO_TIPO_ROUTES) },
  { path: 'loggedOut', loadChildren: () => import("./logged-out/logged-out.routes").then(r => r.LOGGED_OUT_ROUTES) },
  { path: 'mercado', loadChildren: () => import("./mercado/mercado.routes").then(r => r.MERCADO_ROUTES) },
  { path: 'parametro', loadChildren: () => import("./parametro/parametro.routes").then(r => r.PARAMETRO_ROUTES) },
  { path: 'produto', loadChildren: () => import("./produto/produto.routes").then(r => r.PRODUTO_ROUTES) },
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const initialNavigation = !BrowserUtils.isInIframe() && !BrowserUtils.isInPopup() 
    ? withEnabledBlockingInitialNavigation() // Set to enabledBlocking to use Angular Universal
    : withDisabledInitialNavigation();
