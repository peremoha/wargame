import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">Wargame</NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuCountry">Countries</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuTank">Tanks</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuArmament">Armaments</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuType">Types</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuProperty">Properties</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuRole">Roles</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} to="/menuMovement">Movements</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Navbar>
      </header>
    );
  }
}
