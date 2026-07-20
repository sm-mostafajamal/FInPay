import FormElements from "../Forms/FormElements";
import Home from "./pages/Home";

export const dashboardRoutes =  [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "about",
    element: <FormElements />,
  }, 
]