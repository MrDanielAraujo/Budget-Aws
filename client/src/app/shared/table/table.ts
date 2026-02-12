export class Table {
  PagePrevious!: number;
  PageNext!: number;
  PageCount!: number;
  PageNow!: number;
  PageSize!: number;
  RegCount!: number;
  Pages: number[] = [];
  Data: any[] = [];
  Skip!: number;
}