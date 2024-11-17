import React, { useState } from "react";
import {
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  IconButton,
  Divider,
  Toolbar,
  Typography
} from "@mui/material";
import { Link } from "react-router-dom";
import DashboardIcon from "@mui/icons-material/Dashboard";
import AssignmentIcon from "@mui/icons-material/Assignment";
import PeopleIcon from "@mui/icons-material/People";
import MenuIcon from "@mui/icons-material/Menu";
import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";

const drawerWidth = 240;

const Sidebar = () => {
  const [open, setOpen] = useState(true);

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <IconButton
        color="inherit"
        aria-label="open drawer"
        onClick={handleDrawerOpen}
        edge="start"
        sx={{ marginLeft: 2, ...(open && { display: "none" }) }}
      >
        <MenuIcon />
      </IconButton>
      <Drawer
        variant="permanent"
        open={open}
        sx={{
          width: open ? drawerWidth : 60,
          flexShrink: 0,
          whiteSpace: "nowrap",
          boxSizing: "border-box",
          transition: "width 0.3s",
          [`& .MuiDrawer-paper`]: {
            width: open ? drawerWidth : 60,
            transition: "width 0.3s",
            boxSizing: "border-box"
          }
        }}
      >
        <Toolbar>
          <Typography variant="h6" noWrap>
            Hospital Management
          </Typography>
          <IconButton onClick={handleDrawerClose} sx={{ marginLeft: "auto" }}>
            <ChevronLeftIcon />
          </IconButton>
        </Toolbar>
        <Divider />
        <List>
          <ListItem button component={Link} to="/">
            <ListItemIcon>
              <DashboardIcon />
            </ListItemIcon>
            <ListItemText primary="Dashboard" />
          </ListItem>
          <ListItem button component={Link} to="/healthrecords">
            <ListItemIcon>
              <AssignmentIcon />
            </ListItemIcon>
            <ListItemText primary="Health Records" />
          </ListItem>
          <ListItem button component={Link} to="/patients">
            <ListItemIcon>
              <PeopleIcon />
            </ListItemIcon>
            <ListItemText primary="Patients" />
          </ListItem>
        </List>
      </Drawer>
    </div>
  );
};

export default Sidebar;
