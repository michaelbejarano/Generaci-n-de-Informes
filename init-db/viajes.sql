-- =========================================
-- CLIENTES
-- =========================================
CREATE TABLE clientes (
                          cliente_id SERIAL PRIMARY KEY,
                          nombre VARCHAR(100) NOT NULL,
                          apellido VARCHAR(100) NOT NULL,
                          correo VARCHAR(150) UNIQUE NOT NULL,
                          telefono VARCHAR(20),
                          fecha_registro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- =========================================
-- PROVEEDORES
-- =========================================
CREATE TABLE proveedores (
                             proveedor_id SERIAL PRIMARY KEY,
                             nombre VARCHAR(150) NOT NULL,
                             tipo VARCHAR(50) NOT NULL,
                             telefono VARCHAR(20),
                             correo VARCHAR(150),
                             calificacion DECIMAL(3,2) DEFAULT 0,
                             estado BOOLEAN DEFAULT TRUE
);

-- =========================================
-- PAQUETES TURÍSTICOS
-- =========================================
CREATE TABLE paquetes (
                          paquete_id SERIAL PRIMARY KEY,
                          nombre VARCHAR(150) NOT NULL,
                          descripcion TEXT,
                          destino VARCHAR(150) NOT NULL,
                          precio DECIMAL(10,2) NOT NULL,
                          fecha_inicio DATE NOT NULL,
                          fecha_fin DATE NOT NULL,
                          capacidad INT NOT NULL,
                          disponible INT NOT NULL,
                          estado BOOLEAN DEFAULT TRUE
);

-- =========================================
-- ITINERARIOS
-- =========================================
CREATE TABLE itinerarios (
                             itinerario_id SERIAL PRIMARY KEY,
                             paquete_id INT NOT NULL,
                             dia INT NOT NULL,
                             descripcion TEXT NOT NULL,

                             CONSTRAINT fk_itinerario_paquete
                                 FOREIGN KEY (paquete_id)
                                     REFERENCES paquetes(paquete_id)
                                     ON DELETE CASCADE
);

-- =========================================
-- SERVICIOS
-- =========================================
CREATE TABLE servicios (
                           servicio_id SERIAL PRIMARY KEY,
                           nombre VARCHAR(150) NOT NULL,
                           tipo VARCHAR(50) NOT NULL,
                           descripcion TEXT,
                           precio DECIMAL(10,2) DEFAULT 0,
                           proveedor_id INT,

                           CONSTRAINT fk_servicio_proveedor
                               FOREIGN KEY (proveedor_id)
                                   REFERENCES proveedores(proveedor_id)
);

-- =========================================
-- SERVICIOS INCLUIDOS EN PAQUETES
-- =========================================
CREATE TABLE paquete_servicios (
                                   paquete_id INT NOT NULL,
                                   servicio_id INT NOT NULL,
                                   cantidad INT DEFAULT 1,

                                   PRIMARY KEY (paquete_id, servicio_id),

                                   CONSTRAINT fk_ps_paquete
                                       FOREIGN KEY (paquete_id)
                                           REFERENCES paquetes(paquete_id)
                                           ON DELETE CASCADE,

                                   CONSTRAINT fk_ps_servicio
                                       FOREIGN KEY (servicio_id)
                                           REFERENCES servicios(servicio_id)
);

-- =========================================
-- RESERVAS
-- =========================================
CREATE TABLE reservas (
                          reserva_id SERIAL PRIMARY KEY,
                          cliente_id INT NOT NULL,
                          paquete_id INT NOT NULL,
                          fecha_reserva TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                          cantidad_personas INT NOT NULL,
                          total DECIMAL(10,2) NOT NULL,
                          estado VARCHAR(30) DEFAULT 'PENDIENTE',

                          CONSTRAINT fk_reserva_cliente
                              FOREIGN KEY (cliente_id)
                                  REFERENCES clientes(cliente_id),

                          CONSTRAINT fk_reserva_paquete
                              FOREIGN KEY (paquete_id)
                                  REFERENCES paquetes(paquete_id)
);

-- =========================================
-- PAGOS
-- =========================================
CREATE TABLE pagos (
                       pago_id SERIAL PRIMARY KEY,
                       reserva_id INT NOT NULL,
                       fecha_pago TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                       monto DECIMAL(10,2) NOT NULL,
                       metodo_pago VARCHAR(50) NOT NULL,
                       estado VARCHAR(30) DEFAULT 'PENDIENTE',

                       CONSTRAINT fk_pago_reserva
                           FOREIGN KEY (reserva_id)
                               REFERENCES reservas(reserva_id)
                               ON DELETE CASCADE
);

-- =========================================
-- PERSONALIZACIONES
-- =========================================
CREATE TABLE personalizaciones (
                                   personalizacion_id SERIAL PRIMARY KEY,
                                   reserva_id INT NOT NULL,
                                   preferencia VARCHAR(150) NOT NULL,
                                   detalle TEXT,

                                   CONSTRAINT fk_personalizacion_reserva
                                       FOREIGN KEY (reserva_id)
                                           REFERENCES reservas(reserva_id)
                                           ON DELETE CASCADE
);

-- =========================================
-- EVALUACIONES DE PROVEEDORES
-- =========================================
CREATE TABLE evaluaciones_proveedores (
                                          evaluacion_id SERIAL PRIMARY KEY,
                                          proveedor_id INT NOT NULL,
                                          reserva_id INT,
                                          puntuacion INT NOT NULL,
                                          comentario TEXT,
                                          fecha_evaluacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

                                          CONSTRAINT fk_evaluacion_proveedor
                                              FOREIGN KEY (proveedor_id)
                                                  REFERENCES proveedores(proveedor_id),

                                          CONSTRAINT fk_evaluacion_reserva
                                              FOREIGN KEY (reserva_id)
                                                  REFERENCES reservas(reserva_id),

                                          CONSTRAINT chk_puntuacion
                                              CHECK (puntuacion BETWEEN 1 AND 5)
);