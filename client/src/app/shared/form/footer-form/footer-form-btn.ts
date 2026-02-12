export class FooterFormBtn {
  onShowSalvar!: boolean;
  onShowVoltar!: boolean;
  onShowEditar!: boolean;
  onShowDeletar!: boolean;
  onShowCancelar!: boolean;

  updateFooterBtnShow(code: string | null, formReset: boolean) : void {
    this.onShowSalvar = code == '0' || (code != '0' && !formReset);
    this.onShowVoltar = true;
    this.onShowEditar = code != '0' && formReset;
    this.onShowDeletar = code != '0' && formReset;
    this.onShowCancelar = code != '0' && !formReset;
  }
}