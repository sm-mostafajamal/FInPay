import { constants } from "../../app/config/constants";
import CalculateEmi from "./pages/CalculateEmi";

export const loanRoutes =  [
  {
    path: constants.Path.Loan.CalculateEmi,
    element: <CalculateEmi />,
  }, 
]