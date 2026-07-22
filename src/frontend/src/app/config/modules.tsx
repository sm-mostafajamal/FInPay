import { Module } from "../../components/layout/Sidebar/types";
import { dashboardModule } from "../../modules/Dashboard/module";
import { loanModule } from "../../modules/Loan/module";

export const modules: Module[] = [
  dashboardModule,
  loanModule,
];