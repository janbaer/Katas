export function createAccount(owner: string) {
  return new Account(owner);
}

export interface IAccount {
  owner: string;
  credit: number;
}

export class Account implements IAccount {
  public owner: string;
  public credit: number;

  constructor(owner: string) {
    this.owner = owner;
    this.credit = 200;
  }
}