import { RegisterUser }  from "./components/RegisterUser";
import { RegisterPerson } from "./components/RegisterPerson";
import { Login } from "./components/Login";

const AppRoutes = [
  {
    index: true,
        element: <Login />
  },
  {
      path: '/register-user',
      element: <RegisterUser />
  },
  {
      path: '/register-person',
      element: <RegisterPerson />
  }
];

export default AppRoutes;
