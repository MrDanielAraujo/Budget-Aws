export class FooterTable {
  e!: Event
  type!: "onExportExcel" | "onSelectItem" | "onDelete" | "onImportFile" | "onPagination";
  value!: string | number | boolean;
}