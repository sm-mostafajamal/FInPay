import { RouteObject } from "react-router";
import { dashboardRoutes } from "../../modules/Dashboard/routes";
import { loanRoutes } from "../../modules/Loan/routes";

export const routes : RouteObject[] = [
  ...dashboardRoutes,
  ...loanRoutes,
];