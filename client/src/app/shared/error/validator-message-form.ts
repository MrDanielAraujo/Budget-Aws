export class ValidatorMessageForm {
  Errors!: ValidatorError[];
}

export class ValidatorError {
  InputName!: string | null;
  TypeError!: string;
  Message!: string;
}
